namespace Authentication_Login.Response
{
        public class ApiResponse<T>
        {
            public bool Success { get; set; } = true;
            public ResultBody<T> result { get; set; }
        }

        public class ResultBody<T>
        {
            public int totalAcount { get; set; }
            public IReadOnlyList<T> items { get; set; }
        }
}
