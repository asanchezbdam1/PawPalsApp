using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    [Serializable]
    public class PostList
    {
        public List<Post> Posts;
        public int RequesterID;
        public bool FromRequester;

        public PostList()
        {
            Posts = new List<Post>();
            RequesterID = 0;
            FromRequester = false;
        }
    }
}
