using Demo3.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Demo3.Dto
{
    public class StudentFilterDto
    {
        [FromQuery(Name ="pageSize")]
        public int PageSize { get; set; }
        [FromQuery(Name="pageIndex")]
        public int PageIndex { get; set; }

        private string _keyword;
        [FromQuery(Name = "keyword")]
        
        //public string KeyWord { get; set; }
        public string KeyWord
        {
            get => _keyword;
            set => _keyword = value?.Trim();
                
        }
    }
}
