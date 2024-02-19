using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Discord
{
    public class Discord : IDiscord
    {

        private Dictionary<string, Message> allMessages;
        private Dictionary<string, HashSet<Message>> channels;

        public Discord()
        {
            this.allMessages = new Dictionary<string, Message>();
            this.channels = new Dictionary<string, HashSet<Message>>();
        }

        public void SendMessage(Message message)
        {
            this.allMessages.Add(message.Id, message);

            if (!this.channels.ContainsKey(message.Channel))
            {
                this.channels.Add(message.Channel, new HashSet<Message>());
            }

            this.channels[message.Channel].Add(message);
        }

        public bool Contains(Message message)
        {
            return this.allMessages.ContainsKey(message.Id);
        }

        public int Count => this.allMessages.Count;

        public Message GetMessage(string messageId)
        {
            if (!this.allMessages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }
            return this.allMessages[messageId];
        }

        public void DeleteMessage(string messageId)
        {
            if (!this.allMessages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            var message = this.allMessages[messageId];

            this.allMessages.Remove(messageId);
            this.channels[message.Channel].Remove(message);
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            if (!this.allMessages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            var message = this.allMessages[messageId];
            message.Reactions.Add(reaction);
        }

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            if (!this.channels.ContainsKey(channel))
            {
                throw new ArgumentException();
            }

            var messages = this.channels[channel];

            if (messages.Count == 0)
            {
                throw new ArgumentException();
            }

            return messages;
        }

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
        {
            return this.allMessages.Values
                .Where(m => m.Reactions.Intersect(reactions).Count() == reactions.Count)
                .OrderByDescending(m => m.Reactions.Count())
                .ThenBy(m => m.Timestamp);
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
        {
            return this.allMessages.Values
                .Where(m => m.Timestamp >= lowerBound && m.Timestamp <= upperBound)
                .OrderByDescending(m => this.channels[m.Channel].Count);
        }

        public IEnumerable<Message> GetTop3MostReactedMessages()
        {
            return this.allMessages.Values
                .OrderByDescending(m => m.Reactions.Count)
                .Take(3);
        }

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
        {
            return this.allMessages.Values
                .OrderByDescending(m => m.Reactions.Count())
                .ThenBy(m => m.Timestamp)
                .ThenBy(m => m.Content.Length);
        }



    }
}
