using System.Collections.Generic;

namespace STARAAPP
{
    public class GetWorkersResponse
    {
        public List<Worker> Workers { get; set; }

        public class Worker
        {
            public int ID { get; set; }
            public string Email { get; set; }
        }
    }
}
