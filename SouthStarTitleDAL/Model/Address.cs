using System;

namespace SouthStarTitleDAL.Model
{
    public class Address
    {
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public string FaxPhone { get; set; }
        public string OtherPhone { get; set; }
        public char ActiveFlag { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public DateTime UpdateTimeStamp { get; set; }
        public LuState LuState { get; set; }
    }
}
