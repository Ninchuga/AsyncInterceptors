namespace AsyncInterceptors
{
    public class BaseResponse
	{
		public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return $"{nameof(ErrorMessage)}: {ErrorMessage}";
        }
    }
}
