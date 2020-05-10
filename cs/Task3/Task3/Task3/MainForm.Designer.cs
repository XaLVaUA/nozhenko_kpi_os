namespace Task3
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.workOutButton = new System.Windows.Forms.Button();
            this.leftIntervalTextBox = new System.Windows.Forms.TextBox();
            this.weightRangeLabel = new System.Windows.Forms.Label();
            this.waitingTimeIntensityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.downtimePercentIntensityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.countWaitTimeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.intervalRangeLabel = new System.Windows.Forms.Label();
            this.leftWeightTextBox = new System.Windows.Forms.TextBox();
            this.rightIntervalTextBox = new System.Windows.Forms.TextBox();
            this.rightWeightTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.waitingTimeIntensityChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downtimePercentIntensityChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countWaitTimeChart)).BeginInit();
            this.SuspendLayout();
            // 
            // workOutButton
            // 
            this.workOutButton.Location = new System.Drawing.Point(194, 57);
            this.workOutButton.Name = "workOutButton";
            this.workOutButton.Size = new System.Drawing.Size(75, 23);
            this.workOutButton.TabIndex = 0;
            this.workOutButton.Text = "Ok";
            this.workOutButton.UseVisualStyleBackColor = true;
            this.workOutButton.Click += new System.EventHandler(this.WorkOutButton_Click);
            // 
            // leftIntervalTextBox
            // 
            this.leftIntervalTextBox.Location = new System.Drawing.Point(251, 29);
            this.leftIntervalTextBox.Name = "leftIntervalTextBox";
            this.leftIntervalTextBox.Size = new System.Drawing.Size(100, 22);
            this.leftIntervalTextBox.TabIndex = 1;
            // 
            // weightRangeLabel
            // 
            this.weightRangeLabel.AutoSize = true;
            this.weightRangeLabel.Location = new System.Drawing.Point(12, 9);
            this.weightRangeLabel.Name = "weightRangeLabel";
            this.weightRangeLabel.Size = new System.Drawing.Size(142, 17);
            this.weightRangeLabel.TabIndex = 2;
            this.weightRangeLabel.Text = "Діапазон ваг заявок";
            // 
            // waitingTimeIntensityChart
            // 
            chartArea1.Name = "ChartArea1";
            this.waitingTimeIntensityChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.waitingTimeIntensityChart.Legends.Add(legend1);
            this.waitingTimeIntensityChart.Location = new System.Drawing.Point(12, 96);
            this.waitingTimeIntensityChart.Name = "waitingTimeIntensityChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.waitingTimeIntensityChart.Series.Add(series1);
            this.waitingTimeIntensityChart.Size = new System.Drawing.Size(950, 280);
            this.waitingTimeIntensityChart.TabIndex = 3;
            this.waitingTimeIntensityChart.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Залежність середнього часу очікування від інтенсивності вхідного потоку заявок";
            this.waitingTimeIntensityChart.Titles.Add(title1);
            // 
            // downtimePercentIntensityChart
            // 
            chartArea2.Name = "ChartArea1";
            this.downtimePercentIntensityChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.downtimePercentIntensityChart.Legends.Add(legend2);
            this.downtimePercentIntensityChart.Location = new System.Drawing.Point(12, 382);
            this.downtimePercentIntensityChart.Name = "downtimePercentIntensityChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.downtimePercentIntensityChart.Series.Add(series2);
            this.downtimePercentIntensityChart.Size = new System.Drawing.Size(950, 280);
            this.downtimePercentIntensityChart.TabIndex = 4;
            this.downtimePercentIntensityChart.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Залежність проценту простою ресурсу від  інтенсивності вхідного потоку заявок";
            this.downtimePercentIntensityChart.Titles.Add(title2);
            // 
            // countWaitTimeChart
            // 
            chartArea3.Name = "ChartArea1";
            this.countWaitTimeChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.countWaitTimeChart.Legends.Add(legend3);
            this.countWaitTimeChart.Location = new System.Drawing.Point(12, 668);
            this.countWaitTimeChart.Name = "countWaitTimeChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.countWaitTimeChart.Series.Add(series3);
            this.countWaitTimeChart.Size = new System.Drawing.Size(950, 280);
            this.countWaitTimeChart.TabIndex = 5;
            this.countWaitTimeChart.Text = "chart3";
            title3.Name = "Title1";
            title3.Text = "Залежність кількості заявок від часу очікування";
            this.countWaitTimeChart.Titles.Add(title3);
            // 
            // intervalRangeLabel
            // 
            this.intervalRangeLabel.AutoSize = true;
            this.intervalRangeLabel.Location = new System.Drawing.Point(248, 9);
            this.intervalRangeLabel.Name = "intervalRangeLabel";
            this.intervalRangeLabel.Size = new System.Drawing.Size(343, 17);
            this.intervalRangeLabel.TabIndex = 7;
            this.intervalRangeLabel.Text = "Діапазон інтервалів виникнення наступної заявки ";
            // 
            // leftWeightTextBox
            // 
            this.leftWeightTextBox.Location = new System.Drawing.Point(12, 29);
            this.leftWeightTextBox.Name = "leftWeightTextBox";
            this.leftWeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.leftWeightTextBox.TabIndex = 6;
            // 
            // rightIntervalTextBox
            // 
            this.rightIntervalTextBox.Location = new System.Drawing.Point(357, 29);
            this.rightIntervalTextBox.Name = "rightIntervalTextBox";
            this.rightIntervalTextBox.Size = new System.Drawing.Size(100, 22);
            this.rightIntervalTextBox.TabIndex = 8;
            // 
            // rightWeightTextBox
            // 
            this.rightWeightTextBox.Location = new System.Drawing.Point(118, 29);
            this.rightWeightTextBox.Name = "rightWeightTextBox";
            this.rightWeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.rightWeightTextBox.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(982, 399);
            this.Controls.Add(this.rightWeightTextBox);
            this.Controls.Add(this.rightIntervalTextBox);
            this.Controls.Add(this.intervalRangeLabel);
            this.Controls.Add(this.leftWeightTextBox);
            this.Controls.Add(this.countWaitTimeChart);
            this.Controls.Add(this.downtimePercentIntensityChart);
            this.Controls.Add(this.waitingTimeIntensityChart);
            this.Controls.Add(this.weightRangeLabel);
            this.Controls.Add(this.leftIntervalTextBox);
            this.Controls.Add(this.workOutButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.waitingTimeIntensityChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downtimePercentIntensityChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countWaitTimeChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button workOutButton;
        private System.Windows.Forms.TextBox leftIntervalTextBox;
        private System.Windows.Forms.Label weightRangeLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart waitingTimeIntensityChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart downtimePercentIntensityChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart countWaitTimeChart;
        private System.Windows.Forms.Label intervalRangeLabel;
        private System.Windows.Forms.TextBox leftWeightTextBox;
        private System.Windows.Forms.TextBox rightIntervalTextBox;
        private System.Windows.Forms.TextBox rightWeightTextBox;
    }
}

