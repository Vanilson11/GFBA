namespace GFBA.Communication.Responses;
public class ResponseErrorMessages
{
    public List<string> ErrorsMessages { get; set; } = [];

    public ResponseErrorMessages(List<string> errors)
    {
        ErrorsMessages = errors;
    }
}
