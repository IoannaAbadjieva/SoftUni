using System;
using System.Collections.Generic;
using System.Linq;

namespace Kubernetes
{
    public class Controller : IController
    {
        private Dictionary<string, Pod> podsById;
        private Dictionary<string, Dictionary<string, Pod>> podsByNamespace;


        public Controller()
        {
            this.podsById = new Dictionary<string, Pod>();
            this.podsByNamespace = new Dictionary<string, Dictionary<string, Pod>>();
        }

        public bool Contains(string podId)
        {
            return this.podsById.ContainsKey(podId);
        }

        public void Deploy(Pod pod)
        {
            this.podsById.Add(pod.Id, pod);

            if (!this.podsByNamespace.ContainsKey(pod.Namespace))
            {
                this.podsByNamespace[pod.Namespace] = new Dictionary<string, Pod>();
            }

            this.podsByNamespace[pod.Namespace].Add(pod.Id, pod);
        }

        public Pod GetPod(string podId)
        {
            if (!this.podsById.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            return this.podsById[podId];
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
        {
            return this.podsById.Values
                .Where(p => p.Port >= lowerBound && p.Port <= upperBound);
        }

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
        {
            return this.podsByNamespace[@namespace].Values;

        }

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
        {
            return this.podsById.Values
                 .OrderByDescending(p => p.Port)
                 .ThenBy(p => p.Namespace);
        }

        public int Size()
        {
            return this.podsById.Count;
        }

        public void Uninstall(string podId)
        {
            if (!this.podsById.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            var pod = this.podsById[podId];

            this.podsByNamespace[pod.Namespace].Remove(podId);
            this.podsById.Remove(podId);
        }

        public void Upgrade(Pod pod)
        {
            if (!this.podsById.ContainsKey(pod.Id))
            {
                this.Deploy(pod);
                return;
            }

            var podToUpgrade = this.podsById[pod.Id];

            if (pod.Namespace == podToUpgrade.Namespace)
            {
                this.podsByNamespace[pod.Namespace][pod.Id] = pod;
                this.podsById[pod.Id] = pod;
                return;
            }

            this.podsByNamespace[podToUpgrade.Namespace].Remove(podToUpgrade.Id);

            if (!this.podsByNamespace.ContainsKey(pod.Namespace))
            {
                this.podsByNamespace.Add(pod.Namespace, new Dictionary<string, Pod>());
            }

            this.podsByNamespace[pod.Namespace].Add(pod.Id, pod);
            this.podsById[pod.Id] = pod;
        }
    }
}