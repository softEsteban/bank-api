using System;

namespace BankApi.Api.Dtos
{
    public class ResultDto
    {
        public string State { get; set; }

        public string Data { get; set; }

        public string Message{ get; set; }

        public string Error { get; set; }

    
    public ResultDto(string State, string Data, string Message, string Error)
    {
        this.State = State;
        this.Data = Data;
        this.Message = Message;
        this.Error = Error;
    }

    public ResultDto()
    {
        this.State = "";
        this.Data = ""; 
        this.Message = ""; 
        this.Error = ""; 
    }

    }
}
