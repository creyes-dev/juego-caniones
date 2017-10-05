using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Cañones
{
    public partial class Form1 : Form
    {
        // Proporciones y posiciones
        const double anchoCañon = 73;
        const double altoCañon = 40;
        const int posicionXJugador1 = 10;
        const int posicionXJugador2 = 1280;
        const int radioBola = 20;

        // Variables del juego
        bool turnoJugador2;
        short puntosJugador1;
        short puntosJugador2;

        int posicionYJugador1;
        int posicionYJugador2;
        int posicionConvencionalYJugador1;
        int posicionConvencionalYJugador2;
        
        int posicionInicialXBola;
        int posicionInicialYBola;
        int posicionXBola;
        int posicionYBola;

        bool bolaDisparada;
        long decimasSegundoDesdeDisparo;
        double radianesAngulo;
        double componenteVectorVelocidadInicialX;
        double componenteVectorVelocidadInicialY;

        // Variables utilizadas para la detección de colisiones
        int limiteSuperiorCañon1;
        int limiteInferiorCañon1;
        int limiteSuperiorCañon2;
        int limiteInferiorCañon2;

        int limiteIzquierdoCañon1;
        int limiteDerechoCañon1;
        int limiteIzquierdoCañon2;
        int limiteDerechoCañon2;

        public Form1()
        {
            InitializeComponent();
        }

        // Obtiene la coordenada convencional en el eje Y y la convierte a 
        // una coordenada que corresponde con el sistema de coordenadas
        // del winform
        private int CoordenadaVerticalWinForm(int coordVerticalConvencional)
        {
            int coordenadaVerticalWinForm = this.Height - coordVerticalConvencional;
            return coordenadaVerticalWinForm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NuevoJuego();
        }

        // 1. NUEVO JUEGO
        private void NuevoJuego()
        {
            // Cada vez que se inicia un nuevo juego se reinician los
            // puntajes en cero
            puntosJugador1 = 0;
            puntosJugador2 = 0;

            NuevoTurno();
            this.timer1.Enabled = true;
        }

        // 2. NUEVO TURNO
        private void NuevoTurno()
        {
            // Mostrar los puntajes
            this.lblPuntajeJugador1.Text = puntosJugador1.ToString();
            this.lblPuntajeJugador2.Text = puntosJugador2.ToString();

            // Mostrar el turno del jugador
            this.lblTurnoJugador.Text = (turnoJugador2) ? "Jugador 2" : "Jugador 1";
            
            // 3. VERIFICAR PUNTAJES
            // Si es el turno del jugador 1 verificar si algún jugador ya ha ganado
            if (!turnoJugador2)
            {
                // Si ambos tienen 3 o mas puntos algunos de los dos ya pudo haber ganado
                if (puntosJugador1 >= 3 || puntosJugador2 >= 3)
                {
                    // Si ambos poseen distinto puntaje es porque no hay empate y uno de los
                    // dos ha ganado
                    if (puntosJugador1 != puntosJugador2)
                    {
                        FinDelJuego();
                    }
                }
            }

            // Posicionar los cañones en un punto al azar
            Random r = new Random();
            posicionYJugador1 = r.Next(200, 700);
            posicionYJugador2 = r.Next(200, 700);

            posicionConvencionalYJugador1 = posicionYJugador1;
            posicionConvencionalYJugador2 = posicionYJugador2;

            posicionYJugador1 = CoordenadaVerticalWinForm(posicionYJugador1);
            posicionYJugador2 = CoordenadaVerticalWinForm(posicionYJugador2);

            // Registrar en variables valores utilizados para la detección de colisiones
            limiteSuperiorCañon1 = this.posicionYJugador1;
            limiteInferiorCañon1 = this.posicionYJugador1 + Convert.ToInt32(altoCañon);
            limiteSuperiorCañon2 = this.posicionYJugador2;
            limiteInferiorCañon2 = this.posicionYJugador2 + Convert.ToInt32(altoCañon);
            limiteIzquierdoCañon1 = posicionXJugador1;
            limiteDerechoCañon1 = posicionXJugador1 + Convert.ToInt32(Math.Round(anchoCañon,0));
            limiteIzquierdoCañon2 = posicionXJugador2;
            limiteDerechoCañon2 = posicionXJugador2 + Convert.ToInt32(Math.Round(anchoCañon, 0));

            // Informar de quien es el nuevo turno
            string descrTurno = "turno del " + this.lblTurnoJugador.Text;
            MessageBox.Show(descrTurno);

            // Habilitar el boton de tiro
            btnDisparo.Enabled = true;
        }

        private void FinTurno()
        {
            turnoJugador2 = !turnoJugador2;
            bolaDisparada = false;
        }

        // 4. DISPARAR CAÑON
        private void btnDisparo_Click(object sender, EventArgs e)
        {
            // Posicionar la bola en el cañón
            // Definir las posiciones utilizando el sistema de coordenadas
            // convencional. Al desplazarse bola será dibujada
            // utilizando el sistema de coordenadas del winform 
            if (turnoJugador2)
            {
                posicionInicialXBola = posicionXJugador2 - 5;
                posicionInicialYBola = posicionConvencionalYJugador2;
            }
            else
            {
                posicionInicialXBola = posicionXJugador1 + Convert.ToInt32(anchoCañon);
                posicionInicialYBola = posicionConvencionalYJugador1;
            }

            posicionXBola = posicionInicialXBola;
            posicionYBola = posicionInicialYBola;

            // Calcular los componentes del vector velocidad inicial 
            // que son necesarios para calcular la posición del 
            // proyectil en determinado momento
            CalcularComponentesVectorVelocidad();

            decimasSegundoDesdeDisparo = 0;
            bolaDisparada = true;

            this.btnDisparo.Enabled = false;
        }

        // Cada 1 decima de segundo dibujar los elementos del juego
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();

            // 5. MOVER LA BOLA
            if (bolaDisparada)
            {
                DibujarBola();
            }
            DibujarJugadores();
            // 6. DETECTAR COLISIONES
            ControlarColisionesBola();
        }

        private void DibujarBola()
        {
                Brush colorBola = Brushes.Blue;
                int direccionHorizontalBola = 1;

                if (turnoJugador2)
                {
                    colorBola = Brushes.Red;
                    direccionHorizontalBola = -1;
                }

                // han pasado 100ms (1 decima de segundo)
                // porque esta funcion es llamada cada 100ms
                decimasSegundoDesdeDisparo += 1;

                // calcular la nueva coordenada de x
                //X =X_0 + V_0x(t) 
                double posicionX = Math.Round(posicionInicialXBola + direccionHorizontalBola * (componenteVectorVelocidadInicialX * (decimasSegundoDesdeDisparo * 0.1)), 0);
                posicionXBola = Convert.ToInt32(posicionX);

                // calcular la nueva coordenada de y
                // Y = Y_0 + V_0y(t-t_0)-1/2g(t-t_0)^2
                double decimasSegundoAlCuadrado = decimasSegundoDesdeDisparo * 0.1;
                double posicionY = Math.Round(((posicionInicialYBola + componenteVectorVelocidadInicialY * (decimasSegundoDesdeDisparo * 0.1)) - (0.5 * 9.8 * Math.Pow(decimasSegundoDesdeDisparo * 0.1, 2))), 0);
                posicionYBola = Convert.ToInt32(Math.Round(posicionY, 0));
                posicionYBola = CoordenadaVerticalWinForm(posicionYBola);

                //Dibujar la bola
                Graphics graficos = this.CreateGraphics();
                graficos.FillEllipse(colorBola, posicionXBola, posicionYBola, radioBola, radioBola);
        }

        private void DibujarJugadores()
        {
            Graphics graficos = this.CreateGraphics();

            string directorioEjecutable = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dirImagenJugador = directorioEjecutable + "\\cannon1.png";

            Bitmap imagen = new Bitmap(dirImagenJugador);
            graficos.DrawImageUnscaled(imagen, posicionXJugador1, posicionYJugador1);

            dirImagenJugador = directorioEjecutable + "\\cannon2.png";
            imagen = new Bitmap(dirImagenJugador);
            graficos.DrawImageUnscaled(imagen, posicionXJugador2, posicionYJugador2);
        }

        private void ControlarColisionesBola()
        {
            if (bolaDisparada)
            {
                // 7. DETECTAR SI LA BOLA TRASPASA LOS LIMITES DEL PLANO
                // Verificar si la bola pasa los límites de la ventana 
                if (BolaTraspasaLimitesVentana())
                {
                    FinTurno();
                    NuevoTurno();
                }
                else
                {
                    if (BolaImpactaCañon())
                    {
                        if (turnoJugador2)
                        {
                            puntosJugador2++;
                        }
                        else
                        {
                            puntosJugador1++;
                        }

                        FinTurno();
                        MessageBox.Show("La bola ha impactado al cañón, el jugador gana un punto");
                        NuevoTurno();
                    }
                }

            }
        }

        private void FinDelJuego()
        {
            timer1.Enabled = false;

            // Definir ganador
            string jugadorGanador = "Jugador 1";
            if (puntosJugador2 > puntosJugador1)
            {
                MessageBox.Show("El ganador es " + jugadorGanador);
            }

            // Preguntar si desea seguir jugando
            if (MessageBox.Show("¿Desea jugar nuevamente?", "Nuevo juego", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                NuevoJuego();
            }
            else
            {
                Application.Exit();
            }
        }
        
        private bool BolaTraspasaLimitesVentana()
        {
            bool bolaTraspasaLimitesVentana = false;

            // La bola cae traspasando el límite inferior de la ventana
            if (posicionYBola > this.Height)
            {
                bolaTraspasaLimitesVentana = true;
            }
            else
            {
                // La bola traspasa el límite derecho de la ventana
                if (posicionXBola > this.Width)
                {
                    bolaTraspasaLimitesVentana = true;
                }
                else
                {
                    // La bola traspasa el límite izquierdo de la ventana
                    if (posicionXBola - radioBola < 0)
                    {
                        bolaTraspasaLimitesVentana = true;
                    }
                }
            }
            return bolaTraspasaLimitesVentana;
        }

        private bool BolaImpactaCañon()
        {
            bool bolaImpactaCañon = false;

            // int limiteSuperiorBola = CoordenadaVerticalWinForm(posicionYBola);
            int limiteSuperiorBola = posicionYBola;
            int limiteInferiorBola = limiteSuperiorBola + (radioBola);
            int limiteIzquierdoBola = posicionXBola;
            int limiteDerechoBola = posicionXBola + (radioBola);

            // Verificar si los límites superior e inferior
            // de la bola se encuentran posicionados dentro
            // del rango de valores de los límites superior e 
            // inferior del cañón

            int limiteSuperiorCañon = limiteSuperiorCañon2;
            int limiteInferiorCañon = limiteInferiorCañon2 + 12;
            int limiteIzquierdoCañon = limiteIzquierdoCañon2;
            int limiteDerechoCañon = limiteDerechoCañon2;

            if (turnoJugador2)
            {
                limiteSuperiorCañon = limiteSuperiorCañon1;
                limiteInferiorCañon = limiteInferiorCañon1 + 12;
                limiteIzquierdoCañon = limiteIzquierdoCañon1;
                limiteDerechoCañon = limiteDerechoCañon1;
            }

            // Verificar si la bola se encuentra en los límites superior y superior del cañón  
            if (limiteSuperiorCañon <= limiteInferiorBola && limiteInferiorCañon >= limiteSuperiorBola)
            {
                if (limiteIzquierdoBola <= limiteDerechoCañon && limiteDerechoBola >= limiteIzquierdoCañon)
                {
                    bolaImpactaCañon = true;

                }
            }
            
            return bolaImpactaCañon;
        }
        
        private void CalcularComponentesVectorVelocidad()
        {   
            double velocidadInicial = Convert.ToDouble(this.txtVelocidadInicial.Text);
            double angulo = Convert.ToDouble(this.txtAngulo.Text);

            // Convierto los angulos a radianes 
            radianesAngulo = angulo * (Math.PI / 180);

            // V_0x = V_0*Cos(alpha)
            componenteVectorVelocidadInicialX = velocidadInicial * Math.Cos(radianesAngulo);

            // V_0y = V_0*sin(alpha)
            componenteVectorVelocidadInicialY = velocidadInicial * Math.Sin(radianesAngulo);
        }

    }
}
