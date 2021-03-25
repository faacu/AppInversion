
namespace StockBriefCase
{
    partial class Dividendos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelMensual = new System.Windows.Forms.Label();
            this.labelHoy = new System.Windows.Forms.Label();
            this.accionesTableAdapter1 = new StockBriefCase.BDAccionesDataSetTableAdapters.AccionesTableAdapter();
            this.tableAdapterManager1 = new StockBriefCase.BDAccionesDataSetTableAdapters.TableAdapterManager();
            this.bdAccionesDataSet1 = new StockBriefCase.BDAccionesDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdAccionesDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 262);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Ganancias";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(776, 176);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Location = new System.Drawing.Point(296, 227);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(143, 29);
            this.buttonActualizar.TabIndex = 1;
            this.buttonActualizar.Text = "Actualizar";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelHoy);
            this.panel1.Controls.Add(this.labelMensual);
            this.panel1.Controls.Add(this.labelTotal);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 67);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(23, 20);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(90, 31);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "Total: ";
            // 
            // labelMensual
            // 
            this.labelMensual.AutoSize = true;
            this.labelMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensual.Location = new System.Drawing.Point(278, 20);
            this.labelMensual.Name = "labelMensual";
            this.labelMensual.Size = new System.Drawing.Size(131, 31);
            this.labelMensual.TabIndex = 1;
            this.labelMensual.Text = "Mensual: ";
            // 
            // labelHoy
            // 
            this.labelHoy.AutoSize = true;
            this.labelHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHoy.Location = new System.Drawing.Point(551, 20);
            this.labelHoy.Name = "labelHoy";
            this.labelHoy.Size = new System.Drawing.Size(78, 31);
            this.labelHoy.TabIndex = 2;
            this.labelHoy.Text = "Hoy: ";
            // 
            // accionesTableAdapter1
            // 
            this.accionesTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.AccionesTableAdapter = this.accionesTableAdapter1;
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.UpdateOrder = StockBriefCase.BDAccionesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bdAccionesDataSet1
            // 
            this.bdAccionesDataSet1.DataSetName = "BDAccionesDataSet";
            this.bdAccionesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Dividendos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.chart1);
            this.Name = "Dividendos";
            this.Text = "Dividendos";
            this.Load += new System.EventHandler(this.Dividendos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdAccionesDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelMensual;
        private System.Windows.Forms.Label labelHoy;
        private BDAccionesDataSetTableAdapters.AccionesTableAdapter accionesTableAdapter1;
        private BDAccionesDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private BDAccionesDataSet bdAccionesDataSet1;
    }
}