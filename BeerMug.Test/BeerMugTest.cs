using BeerMug.Model;
using NUnit.Framework;

namespace BeerMug.Test
{
    [TestFixture]
    public class MugTest
    {
        private MugParameters _mugParameters;

        [TestCase(Description = "���������� ���� ������� BelowBottomRadius")]
        public void Test_BelowBottomRadius_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double expected = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.AreEqual(expected, _mugParameters.BelowBottomRadius, "�������� ������ ������� � " +
                                                                        "�������� �� 50 �� 70");/// ������� �������� ��� -30 = ������� ������� ���
        }

        [TestCase(50, Description = "���������� ���� ������� BelowBottomRadius")]
        public void Test_BelowBottomRadius_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.AreEqual(value, _mugParameters.BelowBottomRadius,
                "�������� ������ ������� � �������� �� 50 �� 70");
        }

        [TestCase(30, Description = "���������� ���� ������� BelowBottomRadius")]
        [TestCase(90, Description = "���������� ���� ������� BelowBottomRadius")]

        public void Test_BelowBottomRadius_Set_IncorrectValue(double wrongBelowBottomRadius)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.BelowBottomRadius = wrongBelowBottomRadius;
            }, "������ ��������� ����������, ���� �������� �� ������ � " +
            "�������� �� 50 �� 70");
        }

        [TestCase(60, Description = "���������� ���� ������� BelowBottomRadius")]
        public void Test_BelowBottomRadius_Set_IncorrectValueAddiction(double wrongBelowBottomRadius)
        {
            _mugParameters = new MugParameters();
            double expected = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            Assert.Throws<Exception>(() =>
            {
                _mugParameters.BelowBottomRadius = wrongBelowBottomRadius;
            }, "������� ������� ��� ������ ���� �� 30 ������ �������� ��� ��������");///������� ������� ��� +30 = ������� �������� ���
        }

        [TestCase(Description = "���������� ���� ������� HighBottomDiametr")]
        public void Test_HighBottomDiametr_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 80;
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            var actual = _mugParameters.HighBottomDiametr;
            Assert.AreEqual(expected, actual, "�������� ������ ������� � " +
                                              "�������� �� 80 �� 100");

        }

        [TestCase(80, Description = "���������� ���� ������� HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.AreEqual(value, _mugParameters.HighBottomDiametr,
                "�������� ������ ������� � �������� �� 80 �� 100");

        }

        [TestCase(40, Description = "���������� ���� ������� HighBottomDiametr")]
        [TestCase(120, Description = "���������� ���� ������� HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_IncorrectValue(double wrongHighBottomDiametr)
        {
            _mugParameters = new MugParameters();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.HighBottomDiametr = wrongHighBottomDiametr;
            }, "������ ��������� ����������, ���� �������� �� ������ � " +
                   "�������� �� 80 �� 100");
        }

        [TestCase(80, Description = "���������� ���� ������� HighBottomDiametr")]
        public void Test_HighBottomDiametr_Set_IncorrectValueAddiction(double wrongHighBottomDiametr)
        {
            _mugParameters = new MugParameters();
            _mugParameters.MugNeckDiametr = 90;
            Assert.Throws<Exception>(() =>
            {
                _mugParameters.HighBottomDiametr = wrongHighBottomDiametr;
            }, "������� ������� ��� ������ ���� ����� �������� ����� ������");///������� ������� ��� � ������� ������ = 1 � 1
        }

        [TestCase(Description = "���������� ���� ������� BottomThickness")]
        public void Test_BottomThickness_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 10;
            _mugParameters.High = 100;
            _mugParameters.BottomThickness = expected;
            var actual = _mugParameters.BottomThickness = expected;
            Assert.AreEqual(expected, actual, "�������� ������ ������� � " +
                                              "�������� �� 10 �� 16,5"); /// 1 � 10 10 = 100
        }

        [TestCase(10, Description = "���������� ���� ������� BottomThickness")]
        public void Test_BottomThickness_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.AreEqual(value, _mugParameters.BottomThickness,
                "�������� ������ ������� � �������� �� 10 �� 16,5"); ///1 � 10
        }

        [TestCase(12, Description = "���������� ���� ������� BottomThickness")]
        public void Test_BottomThickness_Set_IncorrectValueAddiction(double wrongBottomThickness)
        {
            _mugParameters = new MugParameters();
            double belowBottom = 50;
            double highBottom = 80;
            double neck = 80;
            double high = 100;
            double bottomThickness = 10;
            double wallThickness = 5;
            _mugParameters.MugNeckDiametr = neck;
            _mugParameters.HighBottomDiametr = highBottom;
            _mugParameters.High = high;
            _mugParameters.BottomThickness = bottomThickness;
            _mugParameters.WallThickness = wallThickness;
            _mugParameters.BelowBottomRadius = belowBottom;
            Assert.Throws<Exception>(() =>
            {
                _mugParameters.BottomThickness = wrongBottomThickness;
            }, "������ ��� ������ ���� � 10 ��� ������ ������ ������");/// 1 � 10
        }

        [TestCase(8, Description = "���������� ���� ������� BottomThickness")]
        [TestCase(20, Description = "���������� ���� ������� BottomThickness")]
        public void Test_BottomThickness_Set_IncorrectValue(double wrongBottomThickness)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.BottomThickness = wrongBottomThickness;
            }, "������ ��������� ����������, ���� �������� �� ������ � " +
                   "�������� �� 10 �� 16,5");
        }

        [TestCase(Description = "���������� ���� ������� High")]
        public void Test_High_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 100;
            _mugParameters.High = expected;
            var actual = _mugParameters.High;
            Assert.AreEqual(expected, actual, "�������� ������ ������� � " +
                                              "�������� �� 100 �� 165");

        }

        [TestCase(100, Description = "���������� ���� ������� High")]
        public void Test_High_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            _mugParameters.High = 100;
            Assert.AreEqual(value, _mugParameters.High,
                "�������� ������ ������� � �������� �� 100 �� 165");

        }

        [TestCase(80, Description = "���������� ���� ������� High")]
        [TestCase(180, Description = "���������� ���� ������� High")]
        public void Test_High_Set_IncorrectValue(double wrongHigh)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.High = wrongHigh;
            }, "������ ��������� ����������, ���� �������� �� ������ � " +
                   "�������� �� 100 �� 165");
        }

        [TestCase(Description = "���������� ���� ������� WallThickness")]
        public void Test_WallThickness_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 5;
            _mugParameters.WallThickness = expected;
            var actual = _mugParameters.WallThickness;
            Assert.AreEqual(expected, actual, "�������� ������ ������� � " +
                                              "�������� �� 5 �� 7");
        }

        [TestCase(5, Description = "���������� ���� ������� WallThickness")]
        public void Test_WallThickness_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            _mugParameters.WallThickness = 5;
            Assert.AreEqual(value, _mugParameters.WallThickness,
                "�������� ������ ������� � �������� �� 5 �� 7");
        }

        [TestCase(1, Description = "���������� ���� ������� WallThickness")]
        [TestCase(10, Description = "���������� ���� ������� WallThickness")]

        public void Test_WallThickness_Set_IncorrectValue(double wrongWallThickness)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _mugParameters.WallThickness = wrongWallThickness;
            }, "������ ��������� ����������, ���� �������� �� ������ � " +
                   "�������� �� 5 �� 7");
        }

        [TestCase(Description = "���������� ���� ������� MugNeckDiametr")]
        public void Test_MugNeckDiametr_Get_CorrectValue()
        {
            _mugParameters = new MugParameters();
            var expected = 80;
            _mugParameters.MugNeckDiametr = expected;
            var actual = _mugParameters.MugNeckDiametr;
            Assert.AreEqual(expected, actual, "�������� ������ ������� � " +
                                              "�������� �� 80 �� 100");
        }

        [TestCase(80, Description = "���������� ���� ������� MugNeckDiametr")]
        public void Test_MugNeckDiametr_Set_CorrectValue(double value)
        {
            _mugParameters = new MugParameters();
            _mugParameters.MugNeckDiametr = 80;
            Assert.AreEqual(value, _mugParameters.MugNeckDiametr,
                "�������� ������ ������� � �������� �� 80 �� 100");
        }

        [TestCase(70, Description = "���������� ���� ������� MugNeckDiametr")]
        [TestCase(110, Description = "���������� ���� ������� MugNeckDiametr")]

        public void Test_MugNeckDiametr_Set_IncorrectValue(double wrongMugNeckDiametr)
        {
            _mugParameters = new MugParameters();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    _mugParameters.MugNeckDiametr = wrongMugNeckDiametr;
                }, "������ ��������� ����������, ���� �������� �� ������ � " +
                   "�������� �� 80 �� 100");
        }

        /// <summary>
        /// ���������� ���� ������� X.
        /// </summary>
        [Test(Description = "���������� ���� ������� X.")]
        public void TestXGet_CorrectValue()
        {
            const int value = 10;
            var point2D = new Point2D(value, 5);
            var actual = point2D.X;
            Assert.AreEqual(value, actual);
        }

        /// <summary>
        /// ���������� ���� ������� Y.
        /// </summary>
        [Test(Description = "���������� ���� ������� Y.")]
        public void TestYGet_CorrectValue()
        {
            const int value = 10;
            var point2D = new Point2D(5, value);
            var actual = point2D.Y;
            Assert.AreEqual(value, actual);
        }

        /// <summary>
        /// ���������� ���� ������ Equals.
        /// </summary>
        [Test(Description = "���������� ���� ������ Equals.")]
        public void TestEquals_CorrectValue()
        {
            var expected = new Point2D(0, 0);
            var actual = new Point2D(0, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}