using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardTest.Models
{
    public class UserNote
    {
        public int NoteNo { get; set; }
        public string NoteTitle { get; set; }
        public int UserNo { get; set; }
        public string UserName { get; set; }
        public DateTime NoteDate { get; set; }
    }
}
