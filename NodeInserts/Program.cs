using NodeClass;
namespace NodeInserts
{
    internal class Program
    {
        #region --Nodes--
        #endregion

        #region IsExists
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
            //לא לשכוח לשמור על הראש
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

                    //while(list.HasNext()&&!list.GetNext().GetValue().Equals(val))
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
            throw new NotImplementedException();
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

           

        }
    }
}