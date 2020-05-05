using _17bang.Pages.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.ViewModel;

namespace _17bang.Pages.Repository
{
    public class ProblemRepository:BaseRepository<ViewModel.ProblemModel>
    {
        private static IList<ViewModel.ProblemModel> _problems;
         static ProblemRepository()
        {
            _problems = new List<ViewModel.ProblemModel>
            {
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name=" M...",Id=1},
                    Status=ProblemStatus.Cancelled,
                     Title="额，怎么说，看下吧，谢谢了{》=《}，我只有五个帮币，呜呜",
                     Id=1,
                     Abstact="ava语言写的代码需要先编译为可执行文件，才能被jvm执行。在下载的jdk安装目录下的bin目录，有两个可执行程序java.exe和javac.exe，javac就是用来编译的，java是执行编译后的class文件。刚写好的java程序是.java结尾的文件，需要经过编译，变为.class结尾的文件，然后交给虚拟机执行。新建一个HelloWorld.java文件，将以下代码贴入：public class HelloWorld { public static void main(String[] args……"
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name=" 28zhu ",Id=2},
                    Status=ProblemStatus.WaitingProcess,
                     Title="如何使用U盘防护系统的运行",
                     Id=2,
                     Abstact="期望功能：当U盘被拔下后，系统崩溃或者退出。经历：之前看"
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name=" 友人.",Id=3},
                    Status=ProblemStatus.InProcess,
                     Title="为什么在给变量a赋值后，再使a=a++之后，输出a的值没有变化。",
                     Id=3,
                     Abstact="",
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name="  28zhu ",Id=4},
                    Status=ProblemStatus.Rewarded,
                     Title=" 有一个自定义UI控件，此控件使用在不同的系统中会有不同的呈现，之前的做法是各种switch case，阅读代码时让人很难受，另外新创建一个用到此控件的系统，要修改代码的地方也多，只要有swich case 的地方都要再加一个case。请教一个好一些的方式来处理这个问题，目的是让代码更加清楚",
                     Id=4,
                     Abstact="RT，也不知道描述的清楚不清楚。求一个思路……",

                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name=" WhiteWater",Id=5},
                    Status=ProblemStatus.Cancelled,
                     Title="手动导入jar包，运行报错的问题",
                     Id=5,
                     Abstact="运行就报这个错误，这个jar包我导入项目了的，不然编译都无法通过。……"
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name="chenzhiwei ",Id=6},
                    Status=ProblemStatus.Cancelled,
                     Title=" electron-vue 项目 存放localStorage 的cookie 问题",
                     Id=6,
                     Abstact="现在是用electron-vue 做的 桌面应用程序用localStorage存放的用户信息重新安装之后 ",
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name=" 28zhu.",Id=7},
                    Status=ProblemStatus.Cancelled,
                     Title=" 使用StackExchange.Redis.dll访问Redis时引用程序集错误",
                     Id=7,
                     Abstact="Message未能加载文件或程序集“System.Runtime.CompilerServices.Unsafe, Vers11d"
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name="  瓜皮弟子头很铁 ",Id=8},
                    Status=ProblemStatus.Rewarded,
                     Title=" System.IndexOutOfRangeException”类型的异常在 System.Data.dll 中发生",
                     Id=8,
                     Abstact="protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)"
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name="  桂ILLL",Id=9},
                    Status=ProblemStatus.InProcess,
                     Title="winform视频通信程序卡顿",
                     Id=9,
                     Abstact="用的是vs2015的winform窗体程序，主要是类似于QQ的视频语音通信，语音功能搁浅了"
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name=" CristanoShow",Id=10},
                    Status=ProblemStatus.Cancelled,
                     Title=" Winform：dockpanel只显示一个活动窗体，其它的标签页全部关闭",
                     Id=10,
                     Abstact="如题：dockpanel显示有多个标签栏，怎么将只显示当前活动窗体的标签栏……"
                },
                new ViewModel.ProblemModel
                {
                    PublishTime=DateTime.Now,
                    Author=new User{Name=" M.",Id=12},
                    Status=ProblemStatus.Cancelled,
                     Title="额，怎么说，看下吧，谢谢，我只有五个帮币，呜呜",
                     Id=12,
                     Abstact="有两个可执行程译，变为.cllic class HelloWorld { public static void main(String[] args……"
                },

            };
        }

        public  void Save(ViewModel.ProblemModel model )
        {
            _problems.Add(model);
        }

        public IList<ViewModel.ProblemModel> GetProblems()
        {
            return _problems;
        }
        public IList<ViewModel.ProblemModel> GetExclude(ProblemStatus status)
        {
            return _problems.Where(p => p.Status != status).ToList();
        }
        //public IList<Problem> GetPaged(int pageIndex,int pageSize)
        //{
        //    return _problems.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        //}
        public int GetSum()
        {
            return _problems.Count;
        }
        public ViewModel.ProblemModel GetSingle(int Id)
        {
            return _problems.SingleOrDefault(p => p.Id == Id);
        }
    }
}
