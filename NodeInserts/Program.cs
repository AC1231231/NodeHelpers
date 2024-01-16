using NodeClass;
namespace NodeInserts
{
    internal class Program
    {
        #region --Nodes--
        #endregion

        #region IsExists
        // האם ערך מסוים בשרשרת
        public static bool IsExists<T>(Node<T> list, T value)
        {
            while (list != null)
            {
                if (list.GetValue().Equals(value))
                    return true;
                list = list.GetNext();
            }
            return false;
        }
        #endregion

        #region Count Nodes
        //סופר מספר חוליות בשרשרת
        public static int CountList<T>(Node<T> head)
        {
            int counter = 0;
            while (head != null)
            {
                counter++;
                head = head.GetNext();//i++
            }
            return counter;
        }
        #endregion

        #region Delete

        public static Node<T> DeleteWithDummy<T>(Node<T> list, T val)
        {
            Node<T> dummy = new Node<T>(default(T), list);

            Node<T> next = dummy.GetNext();
            Node<T> current = dummy;
            while (next != null && !next.GetValue().Equals(val))
            {
                current = current.GetNext();
                next = current.GetNext();
            }
            //מצאתי את הערך!!!!
            if (next != null)
            {
                current.SetNext(next.GetNext());
                next.SetNext(null);


            }
            return dummy.GetNext();
        }      
        public static Node<T> Delete<T>(Node<T> list, T val)
        {
            //
            Node<T> head = list;
            //יש מאיפה למחוק
            if (list != null)
            {
                //נבדוק האם הערך נמצא בחוליה הראשונה
                if (list.GetValue().Equals(val))
                {
                    //נעדכן ראש חדש
                    head = list.GetNext();
                    //ננתק את הראש הישן
                    list.SetNext(null);
                }
                //הערך נמצא בחוליה בהמשך
                else
                {
                    //נחפש את החוליה שמכילה את הערך

                    Node<T> next = list.GetNext();
                    while (next != null && !next.GetValue().Equals(val))
                    {
                        list = list.GetNext();
                        next = list.GetNext();
                    }
                    //מצאתי את הערך!!!!
                    if (next != null)
                    {
                        list.SetNext(next.GetNext());
                        next.SetNext(null);


                    }
                }
            }
            return head;
        }
        public static Node<T> DeleteAfterNode<T>(Node<T> node)
        {
            if (node == null || !node.HasNext())
            {
                // If the given node is null or the last node, nothing to delete
                return node;
            }

            Node<T> nextNode = node.GetNext();
            node.SetNext(nextNode.GetNext());

            nextNode = null;

            return node;
        }



        #endregion

        #region Reverse
        public static Node<int> Rev(Node<int> lst)
        {
            Node<int> newlst = null;

            while (lst != null)
            {
                Node<int> newNode = new Node<int>(lst.GetValue(), newlst);
                newlst = newNode;

                lst = lst.GetNext();
            }

            return newlst;
        }


        #endregion

        #region Dupes
        public static int CountNoOfDuplication(Node<int> head, int x)
        {
            if (head == null)
                return 0;
            int count = 0;
            while (head != null)
            {
                while (head != null && head.GetValue() != x)
                {
                    head = head.GetNext();
                }
                if (head != null)
                {
                    count++; 
                    while (head.HasNext() && head.GetNext().GetValue() == x)
                    {
                        head = head.GetNext();
                    }
                    head = head.GetNext();
                }
            }
            return count;
        }
        #endregion

        #region Max
        //פעולה שמוצאת את הערך המקסימלי בשרשרת חוליות
        public static int MaxNodeValue(Node<int> head)
        {
            int max = head.GetValue();
            head = head.GetNext();
            while (head != null)
            {
                if (head.GetValue() > max)
                {
                    max = head.GetValue();
                    head = head.GetNext();

                }

            }
            return max;
        }
        #endregion



        static void Main(string[] args)
            {
            Node<int> n1 = new Node<int>(6);
            Node<int> n2 = new Node<int>(5, n1);
            Node<int> n3 = new Node<int>(4, n2);
            Node<int> n4 = new Node<int>(8, n3);
            Node<int> nB = new Node<int>(9, n4);
            Node<int> n5 = new Node<int>(9, nB);

            Console.WriteLine(n5);
            Console.WriteLine(Rev(n5));

           

            }
    }
}