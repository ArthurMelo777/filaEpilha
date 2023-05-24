using System;

class QueueEmpty : Exception {

}

class StackEmpty : Exception {

}

class Queue {
    // atributos
    private int i = 0, f = 0, n = 1; // inicio, fim, capacidade
    private object[] queue = new object[1];

    // metodos
    public void doub () {
        object[] new_queue = new object[n*2];

        for (int i = 0; i < n; i++) {
            new_queue[i] = queue[i];
        }

        n *= 2;
        queue = new_queue;
    }

    public int size () {
        return (n - i+f) % n;
    }

    public bool isEmpty() {
        if (i == f) {
            return true;
        }
        return false;
    }

    public object first () {
        return queue[i];
    }

    public void enqueue (object o) {
        if (size() == n-1) {
            doub();
        }
        queue[f] = o;
        f = (f+1) % n;
    }

    public object dequeue () {
        if (isEmpty()) {
            throw new QueueEmpty();
        }
        object o = queue[i];
        i = (i+1) % n;
        return o;
    }
}

class Stack {
    //atributos
    private int countSize = 0, n = 1, t = -1; // tamanho, capacidade, topo;
    private object[] stack = new object[1];

    //metodos
    public void doub () {
        object[] new_stack = new object[n*2];

        for (int i = 0; i < n; i++) {
            new_stack[i] = stack[i];
        }

        n *= 2;
        stack = new_stack;
    }

    public int size () {
        return countSize;
    }

    public bool isEmpty() {
        if (countSize == 0) {
            return true;
        }
        return false;
    }

    public object top () {
        return stack[t];
    }

    public void push (object o) {
        if (countSize == n) {
            doub();
        }
        stack[++t] = o;
        countSize++;
    }

    public object pop () {
        if (isEmpty()) {
            throw new StackEmpty();
        }
        countSize--;
        return stack[t--];
    }
}

class Program {
    public static void Main () {
        Queue q = new Queue();
        Console.WriteLine(q.size()); // 0
        Console.WriteLine(q.isEmpty()); // true
        q.enqueue(1);
        q.enqueue(2);
        q.enqueue(3);
        q.enqueue("JHIN");
        Console.WriteLine(q.dequeue()); // 1
        Console.WriteLine(q.dequeue()); // 2
        Console.WriteLine(q.size()); // 2
        Console.WriteLine(q.isEmpty()); // false

        Console.WriteLine("---------------------------------------------------------------------");

        Stack s = new Stack();
        Console.WriteLine(s.size()); // 0
        Console.WriteLine(s.isEmpty()); // true
        s.push(1);
        s.push(2);
        s.push(3);
        s.push("JHIN");
        Console.WriteLine(s.pop()); // JHIN
        Console.WriteLine(s.top()); // 3
        Console.WriteLine(s.pop()); // 3
        Console.WriteLine(s.pop()); // 2
        Console.WriteLine(s.top()); // 1
        Console.WriteLine(s.pop()); // 1
        s.pop(); // ERRO
    }
}