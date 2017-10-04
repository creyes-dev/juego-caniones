namespace Cañones
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPuntajeJugador1Texto = new System.Windows.Forms.Label();
            this.lblPuntajeJugador1 = new System.Windows.Forms.Label();
            this.lblPuntajeJugador2Texto = new System.Windows.Forms.Label();
            this.lblPuntajeJugador2 = new System.Windows.Forms.Label();
            this.lblTurnoActual = new System.Windows.Forms.Label();
            this.lblTurnoJugador = new System.Windows.Forms.Label();
            this.lblAnguloTexto = new System.Windows.Forms.Label();
            this.txtAngulo = new System.Windows.Forms.TextBox();
            this.lblVelocidadTitulo = new System.Windows.Forms.Label();
            this.txtVelocidadInicial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDisparo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPuntajeJugador1Texto
            // 
            this.lblPuntajeJugador1Texto.AutoSize = true;
            this.lblPuntajeJugador1Texto.Location = new System.Drawing.Point(1081, 13);
            this.lblPuntajeJugador1Texto.Name = "lblPuntajeJugador1Texto";
            this.lblPuntajeJugador1Texto.Size = new System.Drawing.Size(96, 13);
            this.lblPuntajeJugador1Texto.TabIndex = 0;
            this.lblPuntajeJugador1Texto.Text = "Puntaje Jugador 1:";
            // 
            // lblPuntajeJugador1
            // 
            this.lblPuntajeJugador1.AutoSize = true;
            this.lblPuntajeJugador1.Location = new System.Drawing.Point(1183, 14);
            this.lblPuntajeJugador1.Name = "lblPuntajeJugador1";
            this.lblPuntajeJugador1.Size = new System.Drawing.Size(0, 13);
            this.lblPuntajeJugador1.TabIndex = 1;
            // 
            // lblPuntajeJugador2Texto
            // 
            this.lblPuntajeJugador2Texto.AutoSize = true;
            this.lblPuntajeJugador2Texto.Location = new System.Drawing.Point(1209, 13);
            this.lblPuntajeJugador2Texto.Name = "lblPuntajeJugador2Texto";
            this.lblPuntajeJugador2Texto.Size = new System.Drawing.Size(96, 13);
            this.lblPuntajeJugador2Texto.TabIndex = 2;
            this.lblPuntajeJugador2Texto.Text = "Puntaje Jugador 2:";
            // 
            // lblPuntajeJugador2
            // 
            this.lblPuntajeJugador2.AutoSize = true;
            this.lblPuntajeJugador2.Location = new System.Drawing.Point(1311, 14);
            this.lblPuntajeJugador2.Name = "lblPuntajeJugador2";
            this.lblPuntajeJugador2.Size = new System.Drawing.Size(0, 13);
            this.lblPuntajeJugador2.TabIndex = 3;
            // 
            // lblTurnoActual
            // 
            this.lblTurnoActual.AutoSize = true;
            this.lblTurnoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoActual.Location = new System.Drawing.Point(12, 13);
            this.lblTurnoActual.Name = "lblTurnoActual";
            this.lblTurnoActual.Size = new System.Drawing.Size(70, 13);
            this.lblTurnoActual.TabIndex = 4;
            this.lblTurnoActual.Text = "Turno actual:";
            // 
            // lblTurnoJugador
            // 
            this.lblTurnoJugador.AutoSize = true;
            this.lblTurnoJugador.Location = new System.Drawing.Point(92, 13);
            this.lblTurnoJugador.Name = "lblTurnoJugador";
            this.lblTurnoJugador.Size = new System.Drawing.Size(0, 13);
            this.lblTurnoJugador.TabIndex = 5;
            // 
            // lblAnguloTexto
            // 
            this.lblAnguloTexto.AutoSize = true;
            this.lblAnguloTexto.Location = new System.Drawing.Point(145, 13);
            this.lblAnguloTexto.Name = "lblAnguloTexto";
            this.lblAnguloTexto.Size = new System.Drawing.Size(43, 13);
            this.lblAnguloTexto.TabIndex = 6;
            this.lblAnguloTexto.Text = "Ángulo:";
            // 
            // txtAngulo
            // 
            this.txtAngulo.Location = new System.Drawing.Point(194, 6);
            this.txtAngulo.Name = "txtAngulo";
            this.txtAngulo.Size = new System.Drawing.Size(35, 20);
            this.txtAngulo.TabIndex = 7;
            this.txtAngulo.Text = "45";
            // 
            // lblVelocidadTitulo
            // 
            this.lblVelocidadTitulo.AutoSize = true;
            this.lblVelocidadTitulo.Location = new System.Drawing.Point(245, 13);
            this.lblVelocidadTitulo.Name = "lblVelocidadTitulo";
            this.lblVelocidadTitulo.Size = new System.Drawing.Size(57, 13);
            this.lblVelocidadTitulo.TabIndex = 8;
            this.lblVelocidadTitulo.Text = "Velocidad:";
            // 
            // txtVelocidadInicial
            // 
            this.txtVelocidadInicial.Location = new System.Drawing.Point(305, 6);
            this.txtVelocidadInicial.Name = "txtVelocidadInicial";
            this.txtVelocidadInicial.Size = new System.Drawing.Size(39, 20);
            this.txtVelocidadInicial.TabIndex = 9;
            this.txtVelocidadInicial.Text = "200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "m/s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "º";
            // 
            // btnDisparo
            // 
            this.btnDisparo.Location = new System.Drawing.Point(390, 4);
            this.btnDisparo.Name = "btnDisparo";
            this.btnDisparo.Size = new System.Drawing.Size(75, 23);
            this.btnDisparo.TabIndex = 12;
            this.btnDisparo.Text = "Disparo";
            this.btnDisparo.UseVisualStyleBackColor = true;
            this.btnDisparo.Click += new System.EventHandler(this.btnDisparo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 782);
            this.Controls.Add(this.btnDisparo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVelocidadInicial);
            this.Controls.Add(this.lblVelocidadTitulo);
            this.Controls.Add(this.txtAngulo);
            this.Controls.Add(this.lblAnguloTexto);
            this.Controls.Add(this.lblTurnoJugador);
            this.Controls.Add(this.lblTurnoActual);
            this.Controls.Add(this.lblPuntajeJugador2);
            this.Controls.Add(this.lblPuntajeJugador2Texto);
            this.Controls.Add(this.lblPuntajeJugador1);
            this.Controls.Add(this.lblPuntajeJugador1Texto);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPuntajeJugador1Texto;
        private System.Windows.Forms.Label lblPuntajeJugador1;
        private System.Windows.Forms.Label lblPuntajeJugador2Texto;
        private System.Windows.Forms.Label lblPuntajeJugador2;
        private System.Windows.Forms.Label lblTurnoActual;
        private System.Windows.Forms.Label lblTurnoJugador;
        private System.Windows.Forms.Label lblAnguloTexto;
        private System.Windows.Forms.TextBox txtAngulo;
        private System.Windows.Forms.Label lblVelocidadTitulo;
        private System.Windows.Forms.TextBox txtVelocidadInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDisparo;
    }
}

