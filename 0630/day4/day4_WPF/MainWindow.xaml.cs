using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        // 회원 관리 ----------------------------------------------------

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtAddr.Focus();
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
                txtTelNo.Focus();
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
                txtAge.Focus();
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
                txtName.Focus();
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
        // 회원등록
        private void btnMemInsert_Click(object sender, RoutedEventArgs e)
        {
             
            Member mSearch = MemMgr.SearchMember(txtName.Text);
            if (mSearch != null)
            {
                DisplayMember(mSearch.Name, mSearch.Addr, mSearch.TelNo, mSearch.Age.ToString());
                MessageBox.Show("이미 등록된 회원입니다.");
                return;
            }
            int iTemp;
            try
            {
                iTemp = int.Parse(txtAge.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("숫자를 입력하세요.");
                return;
            }
            Member m = new Member()
            { 
                Name = txtName.Text, 
                Addr = txtAddr.Text, 
                TelNo = txtTelNo.Text, 
                Age = iTemp
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
        // 회원 검색
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
        // 회원 출력
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

        private void btnModifyMember_Click(object sender, RoutedEventArgs e)
        {
            if (listSearchResult.SelectedItem == null)
            {
                MessageBox.Show("회원 출력 후 수정할 회원을 선택하세요.");
                return;
            }
            Member m = (Member)listSearchResult.SelectedItem;
            if (txtAddr.Text == "" || txtTelNo.Text == "" || txtAge.Text == "")
            {
                MessageBox.Show("수정할 내용을 입력하세요.");
                return;
            }
            if (m.Name != txtName.Text)
            {
                MessageBox.Show("이름은 변경할 수 없습니다.");
                DisplayMember(m.Name, txtAddr.Text, txtTelNo.Text, txtAge.Text);
                return;
            }
            MemMgr.ModifyMember(m, txtAddr.Text, txtTelNo.Text, int.Parse(txtAge.Text));

            listSearchResult.Items.Clear();
            MemMgr.PrintAllMember(listSearchResult);
        }

        private void btnDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            if (listSearchResult.SelectedItem == null)
            {
                MessageBox.Show("회원 출력 후 삭제할 회원을 선택하세요.");
                return;
            }
            Member m = (Member)listSearchResult.SelectedItem;
            MemMgr.DeleteMember(m);

            listSearchResult.Items.Clear();
            MemMgr.PrintAllMember(listSearchResult);
        }
        private MemberMgr MemMgr = new MemberMgr();
        
        // 비디오 관리

        private void txtVideoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtTitle.Focus();
        }
        private void txtVideoNo_GotFocus(object sender, RoutedEventArgs e)
        {
            txtVideoNo.Background = Brushes.Yellow;
        }
        private void txtVideoNo_LostFocus(object sender, RoutedEventArgs e)
        {
            txtVideoNo.Background = Brushes.White;
        }
        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtActor.Focus();
        }
        private void txtTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTitle.Background = Brushes.Yellow;
        }
        private void txtTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            txtTitle.Background = Brushes.White;
        }
        private void txtActor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtPrice.Focus();
        }
        private void txtActor_GotFocus(object sender, RoutedEventArgs e)
        {
            txtActor.Background = Brushes.Yellow;
        }
        private void txtActor_LostFocus(object sender, RoutedEventArgs e)
        {
            txtActor.Background = Brushes.White;
        }
        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnVideoInsert_Click(sender, e);
                txtVideoNo.Focus();
            }
        }
        private void txtPrice_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPrice.Background = Brushes.Yellow;
        }
        private void txtPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            txtPrice.Background = Brushes.White;
        }

        private void btnVideoInsert_Click(object sender, RoutedEventArgs e)
        {
            Video vSearch = VMgr.SearchVideo(txtVideoNo.Text);
            if (vSearch != null)
            {
                MessageBox.Show("이미 존재하는 비디오입니다.");
                DisplayVideo(vSearch.VideoNo, vSearch.Title, vSearch.Actor, vSearch.Price.ToString());
                return;
            }
            Video newVideo = new Video()
            {
                VideoNo = txtVideoNo.Text,
                Title = txtTitle.Text,
                Actor = txtActor.Text,
                Price = int.Parse(txtPrice.Text)
            };
            VMgr.InsertVideo(newVideo);
            // MessageBox.Show("비디오 등록 완료");
            DisplayVideo("", "", "", "");
        }
        private void btnVideoSearch_Click(object sender, RoutedEventArgs e)
        {
            Video vSearch = VMgr.SearchVideo(txtVideoNo.Text);
            if (vSearch != null)
            {
                DisplayVideo(vSearch.VideoNo, vSearch.Title, vSearch.Actor, vSearch.Price.ToString());
            }
            else
            {
                MessageBox.Show("존재하지 않는 비디오입니다.");
            }
        }

        private void btnPrintAllVideo_Click(object sender, RoutedEventArgs e)
        {
            VideolistSearchResult.Items.Clear();
            VMgr.PrintAllVideo(VideolistSearchResult);
        }
        private void DisplayVideo(string strVideoNo, string strTitle, string strActor, string strPrice)
        {
            txtVideoNo.Text = strVideoNo;
            txtTitle.Text = strTitle;
            txtActor.Text = strActor;
            txtPrice.Text = strPrice;
        }

        private void VideolistSearchResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && VideolistSearchResult.SelectedItem != null)
            {
                Video vSelected = (Video)VideolistSearchResult.SelectedItem;
                DisplayVideo(vSelected.VideoNo, vSelected.Title, vSelected.Actor, vSelected.Price.ToString());
            }
        }

        private void btnModifyVideo_Click(object sender, RoutedEventArgs e)
        {
            if (VideolistSearchResult.SelectedItem == null)
            {
                MessageBox.Show("비디오 출력 후 수정할 비디오를 선택하세요.");
                return;
            }
            Video v = (Video)VideolistSearchResult.SelectedItem;
            if (txtTitle.Text == "" || txtActor.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("수정할 내용을 입력하세요.");
                return;
            }
            if (v.VideoNo != txtVideoNo.Text)
            {
                MessageBox.Show("비디오 번호는 변경할 수 없습니다.");
                DisplayVideo(v.VideoNo, txtTitle.Text, txtActor.Text, txtPrice.Text);
                return;
            }
            VMgr.ModifyVideo(v, txtTitle.Text, txtActor.Text, int.Parse(txtPrice.Text));

            VideolistSearchResult.Items.Clear();
            VMgr.PrintAllVideo(VideolistSearchResult);
        }

        private void btnDeleteVideo_Click(object sender, RoutedEventArgs e)
        {
            if (VideolistSearchResult.SelectedItem == null)
            {
                MessageBox.Show("비디오 출력 후 삭제할 비디오를 선택하세요.");
                return;
            }
            Video v = (Video)VideolistSearchResult.SelectedItem;
            VMgr.DeleteVedio(v);

            VideolistSearchResult.Items.Clear();
            VMgr.PrintAllVideo(VideolistSearchResult);
        }
        private VideoMgr VMgr = new VideoMgr();

    }
    class VideoMgr
    {
        public void ModifyVideo(Video vSeleted, string strTitle, string strActor, int iPrice)
        {
            Video vToModify = m_VideoList.Find(m => m.CompareVideo(vSeleted.VideoNo));
            vToModify.Title = strTitle;
            vToModify.Actor = strActor;
            vToModify.Price = iPrice;
        }
        public void DeleteVedio(Video vSeleted)
        {
            Video vToDelete = m_VideoList.Find(v => v.CompareVideo(vSeleted.VideoNo));
            m_VideoList.Remove(vToDelete);
        }
        public void PrintAllVideo(ListBox VideolistSearchResult)
        {
            m_VideoList.ForEach(v => VideolistSearchResult.Items.Add(v));
        }
        public void InsertVideo(Video v)
        {
            m_VideoList.Add(v);
        }
        public Video SearchVideo(string strVideoNo)
        {
            return m_VideoList.Find(v => v.CompareVideo(strVideoNo));
        }
        private List<Video> m_VideoList = new List<Video>();
    }
    class Video
    {
        public override string ToString()
        {
            return string.Format("비디오번호: {0}\t제목: {1}\t배우: {2}\t가격: {3}", VideoNo, Title, Actor, Price);
        }
        public bool CompareVideo(string strVideoNo)
        {
            return VideoNo == strVideoNo;
        }
        public string VideoNo { get; set; }
        public string Title { get; set; }
        public string Actor { get; set; }
        public int Price { get; set; }
    }
    class MemberMgr
    {
        public void ModifyMember(Member mSeleted, string strAddr, string strTelno, int iAge)
        {
            Member mToModify = m_MemList.Find(m => m.ComparedName(mSeleted.Name));
            mToModify.Addr = strAddr;
            mToModify.TelNo = strTelno;
            mToModify.Age = iAge;
        }
        public void DeleteMember(Member mSeleted)
        {
            Member mToDelete  = m_MemList.Find(m => m.ComparedName(mSeleted.Name));
            m_MemList.Remove(mToDelete);
        }
        public void PrintAllMember(ListBox listSearchResult)
        {
            m_MemList.ForEach(m => listSearchResult.Items.Add(m));
        }
        public Member SearchMember(string txtName)
        {
            return m_MemList.Find(m => m.ComparedName(txtName));
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
