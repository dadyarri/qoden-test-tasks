using System.Collections.Generic;

namespace QodenTestTasks.Task1
{
    public class LinkedArray
    {
        public int Key;
        public ListNode Head;

        public LinkedArray(int key)
        {
            Key = key;
            Head = null;
        }

        public void Insert(int item)
        {
            var newListNode = new ListNode(item);

            if (Head == null)
            {
                Head = newListNode;
                return;
            }

            var currentElement = Head;

            while (currentElement.Next != null)
            {
                currentElement = currentElement.Next;
            }

            currentElement.Next = newListNode;
        }

        public IEnumerable<int> GetListData()
        {
            var currentElement = Head;

            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.Next;
            }
        }

        public override string ToString()
        {
            return $"{Key}: {string.Join(' ', GetListData())}";
        }
    }
}