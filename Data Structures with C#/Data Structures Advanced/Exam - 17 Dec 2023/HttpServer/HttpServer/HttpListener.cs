using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpServer
{
    public class HttpListener : IHttpListener
    {
        private Dictionary<string, HttpRequest> requests = new Dictionary<string, HttpRequest>();
        private LinkedList<HttpRequest> requestsQueue = new LinkedList<HttpRequest>();
        private Dictionary<string, HttpRequest> executedRequests = new Dictionary<string, HttpRequest>();


        public void AddRequest(HttpRequest request)
        {
            this.requests.Add(request.Id, request);
            this.requestsQueue.AddLast(request);
        }

        public void AddPriorityRequest(HttpRequest request)
        {
            if (!this.requests.ContainsKey(request.Id))
            {
                this.requests.Add(request.Id, request);
                this.requestsQueue.AddFirst(request);
                return;
            }

            var shceduled = this.requestsQueue.First.Value;

            if (shceduled.Id == request.Id)
            {
                throw new ArgumentException();
            }

            this.requestsQueue.Remove(request);
            this.requestsQueue.AddFirst(request);
        }

        public bool Contains(string requestId)
        {
            return this.requests.ContainsKey(requestId);
        }

        public int Size()
        {
            return this.requests.Count;
        }

        public void CancelRequest(string requestId)
        {
            if (!this.requests.ContainsKey(requestId))
            {
                throw new ArgumentException();
            }

            var request = this.requests[requestId];
            this.requests.Remove(requestId);
            this.requestsQueue.Remove(request);
        }

        public HttpRequest GetRequest(string requestId)
        {
            if (!this.requests.ContainsKey(requestId))
            {
                throw new ArgumentException();
            }

            return this.requests[requestId];
        }

        public HttpRequest Execute()
        {
            if (this.requests.Count == 0)
            {
                throw new ArgumentException();
            }

            var request = this.requestsQueue.First.Value;

            this.requests.Remove(request.Id);
            this.requestsQueue.Remove(request);

            this.executedRequests.Add(request.Id, request);

            return request;
        }

        public HttpRequest RescheduleRequest(string requestId)
        {
            if (!this.executedRequests.ContainsKey(requestId))
            {
                throw new ArgumentException();
            }

            var request = this.executedRequests[requestId];


            this.executedRequests.Remove(requestId);
            this.requests.Add(requestId, request);
            this.requestsQueue.AddLast(request);

            return request;
        }

        public IEnumerable<HttpRequest> GetByHost(string host)
        {
            return this.requests.Values
                 .Where(r => r.Host == host);
        }

        public IEnumerable<HttpRequest> GetAllExecutedRequests()
        {
            return this.executedRequests.Values;
        }



    }
}
