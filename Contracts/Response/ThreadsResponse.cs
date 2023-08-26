public class ThreadsResponse {

    public int ThreadsCount { get; set; } = 0;
    
    public IEnumerable<Thread> Threads { get; set; } = new IEnumerable<Thread>();

}