namespace ConsoleApp1
{
    public class ArrayList
    {
        private int[] array = new int[10];
        // tailPointer - how many elements;
        private int tailPointer;

        private int[] Enlarge(int pointer, int index)
        {
            if (pointer >= array.Length || index >= array.Length)
            {
                var extendedArray = new int[array.Length * 2];
                for (var i = 0; i < array.Length; i++)
                {
                    extendedArray[i] = array[i];
                }

                array = extendedArray;
            }

            return array;
        }

        public void Insert(int index, int element)
        {
            array = Enlarge(tailPointer, index);

            for (var i = tailPointer; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = element;
            tailPointer += 1;
        }

        public void Push(int element)
        {
            Insert(tailPointer, element);
        }

        public void Remove(int element)
        {
            var index = IndexOf(element);

            if (index == -1)
            {
                return;
            }

            for (var i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            tailPointer -= 1;
        }

        public int Pop()
        {
            var lastElement = array[tailPointer - 1];

            array[tailPointer - 1] = 0;
            tailPointer -= 1;

            return lastElement;
        }

        public int GetAt(int index)
        {
            return array[index];
        }

        public int IndexOf(int element)
        {
            var index = -1;
            for (var i = 0; i < array.Length; i++)
            {
                if (element == array[i])
                {
                    return i;
                }
            }

            return index;
        }

        public void PrintList()
        {
            foreach (var value in array)
            {
                Console.WriteLine(value);
            }
        }

    }
}
