using PhoneBook;
namespace UAbonentListTest
{
    public class UnitTest1
    {
        [Fact]
        public void CorrectPhone_1()
        {
            UAbonentList uAbonentList = new UAbonentList();
            Assert.True(uAbonentList.Insert("Vasya", "+79139504314"));
        }

        [Fact]
        public void CorrectPhone_2()
        {
            UAbonentList uAbonentList = new UAbonentList();
            Assert.False(uAbonentList.Insert("Vasya", "+791395043"));
        }

        [Fact]
        public void CorrectPhone_3()
        {
            UAbonentList uAbonentList = new UAbonentList();
            Assert.True(uAbonentList.Insert("Vasya", "79139504314"));
        }

        [Fact]
        public void CorrectPhone_4()
        {
            UAbonentList uAbonentList = new UAbonentList();
            Assert.False(uAbonentList.Insert("Vasya", ""));
        }

        [Fact]
        public void CorrectPhone_5()
        {
            UAbonentList uAbonentList = new UAbonentList();
            Assert.False(uAbonentList.Insert("", "79139504314"));
        }

        [Fact]
        public void CorrectPhone_6()
        {
            UAbonentList uAbonentList = new UAbonentList();
            Assert.True(uAbonentList.Insert("Vasya", "-79139504314"));
        }

        [Fact]
        public void CorrectRemove_1()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.False(uAbonentList.Remove(""));
        }

        [Fact]
        public void CorrectRemove_2()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.True(uAbonentList.Remove("Vasya"));
        }

        [Fact]
        public void CorrectRemove_3()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.False(uAbonentList.Remove("79139504314"));
        }

        [Fact]
        public void CorrectEdit_1()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.False(uAbonentList.Edit("Vasya", "123"));
        }

        [Fact]
        public void CorrectEdit_2()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.True(uAbonentList.Edit("Vasya", "+79139504314"));
        }

        [Fact]
        public void CorrectEdit_3()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.False(uAbonentList.Edit("V", "79139504314"));
        }

        [Fact]
        public void CorrectEdit_4()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.True(uAbonentList.Edit("Vasya", "+79131231234"));
        }

        [Fact]
        public void CorrectFind_1()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.True(uAbonentList.Find("Vasya", "79131231234"));
        }

        [Fact]
        public void CorrectFind_2()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.True(uAbonentList.Find("Vasya", ""));
        }

        [Fact]
        public void CorrectFind_3()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.True(uAbonentList.Find("", "79139504314"));
        }

        [Fact]
        public void CorrectFind_4()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.False(uAbonentList.Find("Valya", "79131231234"));
        }

        [Fact]
        public void CorrectFind_5()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            Assert.False(uAbonentList.Find("", "7913123123"));
        }

        [Fact]
        public void WorkingClear()
        {
            UAbonentList uAbonentList = new UAbonentList();
            uAbonentList.Insert("Vasya", "79139504314");
            try
            {
                uAbonentList.Clear();
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }
    }
}