using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class QuestionSelectionForm : Form
    {
        public List<Question> SelectedQuestions { get; private set; } = new List<Question>();
        private List<Question> availableQuestions;

        public QuestionSelectionForm(List<Question> questions)
        {
            InitializeComponent();

            availableQuestions = questions;

            checkedListBox1.DrawMode = DrawMode.OwnerDrawVariable;
            checkedListBox1.IntegralHeight = false;

            checkedListBox1.MeasureItem += (s, e) =>
            {
                if (e.Index < 0) return;

                string text = checkedListBox1.Items[e.Index].ToString();
                int width = checkedListBox1.Width - 40;

                Size measuredSize = TextRenderer.MeasureText(
                    text,
                    checkedListBox1.Font,
                    new Size(width, int.MaxValue),
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl
                );

                e.ItemHeight = Math.Max(22, measuredSize.Height + 8);
            };

            checkedListBox1.DrawItem += (s, e) =>
            {
                e.DrawBackground();
                if (e.Index < 0) return;

                string text = checkedListBox1.Items[e.Index].ToString();
                bool isChecked = checkedListBox1.GetItemChecked(e.Index);

                Rectangle checkBoxRect = new Rectangle(e.Bounds.X + 4, e.Bounds.Y + 4, 16, 16);
                CheckBoxRenderer.DrawCheckBox(
                    e.Graphics,
                    checkBoxRect.Location,
                    isChecked ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal
                              : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal
                );

                Rectangle textRect = new Rectangle(e.Bounds.X + 25, e.Bounds.Y + 2, e.Bounds.Width - 30, e.Bounds.Height);

                TextRenderer.DrawText(
                    e.Graphics,
                    text,
                    checkedListBox1.Font,
                    textRect,
                    checkedListBox1.ForeColor,
                    TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl
                );

                e.DrawFocusRectangle();
            };

            foreach (var q in questions)
            {
                checkedListBox1.Items.Add(q);
            }

            // Auto-grow form height based on content
            AutoAdjustFormHeight();
        }

        private void AutoAdjustFormHeight()
        {
            int totalHeight = 0;
            using (Graphics g = checkedListBox1.CreateGraphics())
            {
                foreach (var item in checkedListBox1.Items)
                {
                    string text = item.ToString();
                    Size measuredSize = TextRenderer.MeasureText(
                        text,
                        checkedListBox1.Font,
                        new Size(checkedListBox1.Width - 40, int.MaxValue),
                        TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl
                    );

                    totalHeight += Math.Max(22, measuredSize.Height + 8);
                }
            }

            int minHeight = 350;
            int maxHeight = 700;
            int padding = 60;

            int desiredHeight = Math.Min(Math.Max(totalHeight + btnConfirm.Height + padding, minHeight), maxHeight);
            this.Height = desiredHeight;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SelectedQuestions.Clear();

            foreach (var item in checkedListBox1.CheckedItems)
            {
                SelectedQuestions.Add((Question)item);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
