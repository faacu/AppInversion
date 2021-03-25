namespace StockBriefCase
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonPortafolio = new System.Windows.Forms.Button();
            this.buttonEstadistica = new System.Windows.Forms.Button();
            this.buttonWishlist = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPortafolio
            // 
            this.buttonPortafolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPortafolio.Image = global::StockBriefCase.Properties.Resources.usuario_icono;
            this.buttonPortafolio.Location = new System.Drawing.Point(204, 115);
            this.buttonPortafolio.Name = "buttonPortafolio";
            this.buttonPortafolio.Size = new System.Drawing.Size(156, 40);
            this.buttonPortafolio.TabIndex = 0;
            this.buttonPortafolio.Text = "Portafolio";
            this.buttonPortafolio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPortafolio.UseVisualStyleBackColor = true;
            this.buttonPortafolio.Click += new System.EventHandler(this.buttonPortafolio_Click);
            // 
            // buttonEstadistica
            // 
            this.buttonEstadistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEstadistica.Image = global::StockBriefCase.Properties.Resources.estadisticas_icono;
            this.buttonEstadistica.Location = new System.Drawing.Point(204, 172);
            this.buttonEstadistica.Name = "buttonEstadistica";
            this.buttonEstadistica.Size = new System.Drawing.Size(156, 40);
            this.buttonEstadistica.TabIndex = 1;
            this.buttonEstadistica.Text = "Estadisticas";
            this.buttonEstadistica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEstadistica.UseVisualStyleBackColor = true;
            this.buttonEstadistica.Click += new System.EventHandler(this.buttonEstadistica_Click);
            // 
            // buttonWishlist
            // 
            this.buttonWishlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWishlist.Image = global::StockBriefCase.Properties.Resources.registro_icono;
            this.buttonWishlist.Location = new System.Drawing.Point(204, 230);
            this.buttonWishlist.Name = "buttonWishlist";
            this.buttonWishlist.Size = new System.Drawing.Size(156, 38);
            this.buttonWishlist.TabIndex = 2;
            this.buttonWishlist.Text = "Wishlist";
            this.buttonWishlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonWishlist.UseVisualStyleBackColor = true;
            this.buttonWishlist.Click += new System.EventHandler(this.buttonWishlist_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.Image = global::StockBriefCase.Properties.Resources.salir_icono;
            this.buttonCerrar.Location = new System.Drawing.Point(427, 361);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(131, 40);
            this.buttonCerrar.TabIndex = 4;
            this.buttonCerrar.Text = "Guardar y Salir";
            this.buttonCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::StockBriefCase.Properties.Resources.unidad_icono;
            this.button1.Location = new System.Drawing.Point(204, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Dividendos";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(570, 413);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonWishlist);
            this.Controls.Add(this.buttonEstadistica);
            this.Controls.Add(this.buttonPortafolio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "StockBriefCase";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPortafolio;
        private System.Windows.Forms.Button buttonEstadistica;
        private System.Windows.Forms.Button buttonWishlist;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button button1;
    }
}

