using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class QuestionSelectionForm : Form
    {
        public List<Question> SelectedQuestions { get; private set; } = new List<Question>();
        private List<Question> availableQuestions;
        private ComboBox cmbQuestionType;

        public QuestionSelectionForm(List<Question> questions)
        {
            InitializeComponent();

            availableQuestions = questions;

            // ComboBox for filtering
            cmbQuestionType = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 10),
                Width = 460
            };
            cmbQuestionType.Items.AddRange(new object[]
            {
                "All",
                "Multiple Choice",
                "True/False",
                "Sentence Completion"
            });
            cmbQuestionType.SelectedIndexChanged += cmbQuestionType_SelectedIndexChanged;
            Controls.Add(cmbQuestionType);
            cmbQuestionType.SelectedIndex = 0;

            // Move CheckedListBox down
            checkedListBox1.Top = cmbQuestionType.Bottom + 10;
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

            AutoAdjustFormHeight();
        }

        private void cmbQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cmbQuestionType.SelectedItem.ToString();
            checkedListBox1.Items.Clear();

            IEnumerable<Question> filtered = selectedType switch
            {
                "Multiple Choice" => availableQuestions.Where(q => q is MultipleChoiceQuestion),
                "True/False" => availableQuestions.Where(q => q is TrueFalseQuestion),
                "Sentence Completion" => availableQuestions.Where(q => q is FillInTheBlank),
                _ => availableQuestions
            };

            foreach (var q in filtered)
            {
                checkedListBox1.Items.Add(q);
            }

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
            int padding = 80;

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
