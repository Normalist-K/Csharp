using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace day4_WPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtAddr.Focus();
            }
        }
        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.Background = Brushes.Yellow;
        }
        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            txtName.Background = Brushes.White;
        }
        private void txtAddr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtTelNo.Focus();
            }
        }
        private void txtAddr_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAddr.Background = Brushes.Yellow;
        }
        private void txtAddr_LostFocus(object sender, RoutedEventArgs e)
        {
            txtAddr.Background = Brushes.White;
        }
        private void txtTelNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtAge.Focus();
            }
        }
        private void txtTelNo_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTelNo.Background = Brushes.Yellow;
        }
        private void txtTelNo_LostFocus(object sender, RoutedEventArgs e)
        {
            txtTelNo.Background = Brushes.White;
        }
        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnMemInsert_Click(sender, e);
            }
        }
        private void txtAge_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAge.Background = Brushes.Yellow;
        }
        private void txtAge_LostFocus(object sender, RoutedEventArgs e)
        {
            txtAge.Background = Brushes.White;
        }

        private void btnMemInsert_Click(object sender, RoutedEventArgs e)
        {
            Member mSearch = MemMgr.SearchMember(txtName.Text);
            if (mSearch != null)
            {
                DisplayMember(mSearch.Name, mSearch.Addr, mSearch.TelNo, mSearch.Age.ToString());
                MessageBox.Show("이미 등록된 회원입니다.");
                return;
            }

            Member m = new Member()
            { 
                Name = txtName.Text, 
                Addr = txtAddr.Text, 
                TelNo = txtTelNo.Text, 
                Age = int.Parse(txtAge.Text) 
            };
            MemMgr.InsertMember(m);
            //MessageBox.Show("회원 등록 성공");
            DisplayMember("", "", "", "");
        }
        private void DisplayMember(string strName, string strAddr, string strTelNo, string strAge)
        {
            txtName.Text = strName;
            txtAddr.Text = strAddr;
            txtTelNo.Text = strTelNo;
            txtAge.Text = strAge;
        }
        private MemberMgr MemMgr = new MemberMgr();

        private void btnMemSearch_Click(object sender, RoutedEventArgs e)
        {
            Member mSearch = MemMgr.SearchMember(txtName.Text);
            if (mSearch != null)
            {
                DisplayMember(mSearch.Name, mSearch.Addr, mSearch.TelNo, mSearch.Age.ToString());
            }
            else
            {
                MessageBox.Show("존재하지 않는 회원입니다.");
            }
        }

        private void btnPrintAllMember_Click(object sender, RoutedEventArgs e)
        {
            listSearchResult.Items.Clear();
            MemMgr.PrintAllMember(listSearchResult);
        }

        private void listSearchResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && listSearchResult.SelectedItem != null)
            {
                Member m = (Member)listSearchResult.SelectedItem;
                DisplayMember(m.Name, m.Addr, m.TelNo, m.Age.ToString());
            }
        }
    }
    class MemberMgr
    {
        public void PrintAllMember(ListBox listSearchResult)
        {
            m_MemList.ForEach(m => listSearchResult.Items.Add(m));
        }
        public Member SearchMember(string txtName)
        {
            return m_MemList.Find(m => m.ComparedName(txtName));
        }
        public IEnumerable Next()
        {
            int iStart = 0;
            while (true)
            {
                if (iStart == m_MemList.Count)
                {
                    yield break;
                }
                yield return m_MemList[iStart];
                ++iStart;
            }
        }
        public void InsertMember(Member m)
        {
            m_MemList.Add(m);
        }
        private List<Member> m_MemList = new List<Member>();
    }
    class Member
    {
        public override string ToString()
        {
            return string.Format("이름: {0}\t주소: {1}\t전화번호: {2}\t나이: {3}", Name, Addr, TelNo, Age);
        }
        public bool ComparedName(string strName)
        {
            return Name == strName;
        }

        public string Name { get; set; }
        public string Addr { get; set; }
        public string TelNo { get; set; }
        public int Age { get; set; }
    }
}
