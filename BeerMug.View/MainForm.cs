using System;
using System.Collections.Generic;
using System.Linq;
using BeerMug.Model;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using KompasConnector;
using System.Reflection.Metadata;

namespace BeerMug.View
{
    /// <summary>
    /// ����� �������������� � ������.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// ��������� ������ MugParameters.
        /// </summary>
        private MugParameters _beerMugParametrs = new MugParameters();

        /// <summary>
        /// ���� ��������� ������������ ����.
        /// </summary>  
        private Color _correctColor = Color.White;

        /// <summary>
        /// ���� �� ��������� ������������ ����.
        /// </summary>  
        private Color _incorrectColor = Color.LightPink;

        /// <summary>
        /// �������, c���������� �������� ������ ������ � ��� ���������.
        /// </summary>
        private Dictionary<TextBox, Action<double>> _textBox
            = new Dictionary<TextBox, Action<double>>();

        public MainForm()
        {
            InitializeComponent();
            _textBox = new Dictionary<TextBox, Action<double>>();
            _textBox.Add(outerDiametrTextBox, (outerDiametr)
                => _beerMugParametrs.MugNeckDiametr = outerDiametr);
            _textBox.Add(thicknessTextBox, (wallThickness)
                => _beerMugParametrs.WallThickness = wallThickness);
            _textBox.Add(highTextBox, (high)
                => _beerMugParametrs.High = high);
            _textBox.Add(bottomThicknessTextBox, (bottomThickness)
                => _beerMugParametrs.BottomThickness = bottomThickness);
            _textBox.Add(upperRadiusOfTheBottomTextBox, (highBottomDiametr)
                => _beerMugParametrs.HighBottomDiametr = highBottomDiametr);
            _textBox.Add(lowerRadiusOfTheBottomTextBox, (lowBottomDiametr)
                => _beerMugParametrs.BelowBottomRadius = lowBottomDiametr);
        }

        /// <summary>
        /// ��������� �����������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxValidator_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Focus();
            if (textBox.Text == string.Empty || textBox.Text == ",")
            {
                textBox.Text = string.Empty;
                return;
            }
            try
            {
                _textBox[textBox](double.Parse(textBox.Text));
                textBox.BackColor = _correctColor;
                if (textBox == outerDiametrTextBox)
                {
                    TextBoxValidator_TextChanged(thicknessTextBox, e);
                }
                if (textBox == thicknessTextBox)
                {
                    TextBoxValidator_TextChanged(highTextBox, e);
                }
                if (textBox == highTextBox)
                {
                    TextBoxValidator_TextChanged(bottomThicknessTextBox, e);
                }
                if (textBox == bottomThicknessTextBox)
                {
                    TextBoxValidator_TextChanged(upperRadiusOfTheBottomTextBox, e);
                }
                if (textBox == upperRadiusOfTheBottomTextBox)
                {
                    TextBoxValidator_TextChanged(lowerRadiusOfTheBottomTextBox, e);
                }
            }
            catch
            {
                textBox.BackColor = _incorrectColor;
            }
        }

        /// <summary>
        /// �������� ���������� ����������� ������ ����� ������� � �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckForCommasAndNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && !((e.KeyChar == ',')
                     && (((TextBox)sender).Text.IndexOf(",") == -1)
                    ))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// ��������, ����� textbox �������� ������ �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntegerCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar))
                && !(char.IsDigit(e.KeyChar))
                && !((e.KeyChar == ',')
                && (((TextBox)sender).Text.IndexOf(",") == 1)
            ))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// ��������� ������� �� ������ Minimum size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimumSizeButtom_Click(object sender, EventArgs e)
        {
            outerDiametrTextBox.Text = "80";
            thicknessTextBox.Text = "5";
            highTextBox.Text = "100";
            bottomThicknessTextBox.Text ="10";
            upperRadiusOfTheBottomTextBox.Text ="80";
            lowerRadiusOfTheBottomTextBox.Text ="50";
        }

        /// <summary>
        /// ��������� ������� �� ������ Maximum size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaximumSizeButton_Click(object sender, EventArgs e)
        {
            outerDiametrTextBox.Text = "100";
            thicknessTextBox.Text = "7";
            highTextBox.Text = "165";
            bottomThicknessTextBox.Text = "16,5";
            upperRadiusOfTheBottomTextBox.Text = "100";
            lowerRadiusOfTheBottomTextBox.Text = "70";
        }

        /// <summary>
        /// ��������� ������� �� ������ Build button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buildButton_Click(object sender, EventArgs e)
        {
            if (outerDiametrTextBox.Text == string.Empty ||
                 thicknessTextBox.Text == string.Empty ||
                 highTextBox.Text == string.Empty ||
                 bottomThicknessTextBox.Text == string.Empty ||
                 upperRadiusOfTheBottomTextBox.Text == string.Empty ||
                 lowerRadiusOfTheBottomTextBox.Text == string.Empty ||
                 _beerMugParametrs.Errors.Count > 0)
            {
                MessageBox.Show(_beerMugParametrs.Errors.Last().Value, "Error data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                var builder = new BeerMugBuilder();
                builder.Builder(_beerMugParametrs, capTypeComboBox.SelectedItem.ToString());
            }
        }

        /// <summary>
        /// ���� �������� ��� �������� �����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            outerDiametrTextBox.Text = "90";
            thicknessTextBox.Text = "6";
            highTextBox.Text = "132,5";
            bottomThicknessTextBox.Text = "13,25";
            upperRadiusOfTheBottomTextBox.Text = "90";
            lowerRadiusOfTheBottomTextBox.Text = "60";
            capTypeComboBox.SelectedItem = "Without cap";
        }
    }
}