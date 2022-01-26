namespace ConsoleApp1
{
    public class Stack
    {
        private const int Capacity = 50;
        private char[] array = new char[Capacity];

        private int pointer;

        public void Push(char value)
        {
            if (pointer >= array.Length)
            {
                throw new Exception("Stack is full");
            }

            array[pointer] = value;
            pointer += 1;
        }

        public char Pop()
        {
            if (pointer == 0)
            {
                throw new Exception("There's nothing to remove");
            }

            var value = array[pointer - 1];

            array[pointer - 1] = '0';
            pointer -= 1;

            return value;
        }

        public char Peek()
        {
            var value = array[pointer - 1];

            return value;
        }

    }
}
