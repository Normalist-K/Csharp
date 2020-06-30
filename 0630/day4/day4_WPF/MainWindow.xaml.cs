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

        private void btnMemInsert_Click(object sender, RoutedEventArgs e)
        {
            Member mSearch = MemMgr.SearchMember(txtName.Text);
            if (mSearch != null)
            {
                txtName.Text = mSearch.Name;
                txtAddr.Text = mSearch.Addr;
                txtTelNo.Text = mSearch.TelNo;
                txtAge.Text = mSearch.Age.ToString();
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
            MessageBox.Show("회원 등록 성공");
            txtName.Text = "";
            txtAddr.Text = "";
            txtTelNo.Text = "";
            txtAge.Text = "";
        }
        private MemberMgr MemMgr = new MemberMgr();

        private void btnMemSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    class MemberMgr
    {
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
