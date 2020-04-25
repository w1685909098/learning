using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Entity
{
    public class Problem
    {
        public DateTime PublishTime;
        public User Author;
        public string Title;
        public int Id;
        public string Abstact;
        public ProblemStatus  Status;
    }
    public enum ProblemStatus
    {
        [Description("已撤销")]
        Cancelled,
        [Description("待协助")]
        WaitingProcess,
        [Description("协助中")]
        InProcess,
        [Description("已酬谢")]
        Rewarded,
    }
}
