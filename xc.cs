package xc;
public class cs {
    private static final int CAPACITY = 5;


    private int[] queue = new int[CAPACITY];
    private int size = 0;
    private int frontIndex = 0;
    private int rearIndex = 0;

    // 放入队列
    public synchronized void put(int element) throws InterruptedException {
        // 判断队列是否已满
        if (size == queue.length) {
            //throw new RuntimeException("队列已满");
            // 让线程阻塞
            // 让线程阻塞，并且很方便让另外的线程把它唤醒
            wait(); // 生产者阻塞，等待消费者唤醒
        }

        // 队列中还有空间
        queue[rearIndex] = element;
        rearIndex = rearIndex + 1;
        if (rearIndex == queue.length) {
            rearIndex = 0;
        }

        size++;
        notify();   // 生产者试图唤醒阻塞的消费者
    }

    // 从队列中取
    public synchronized int take() throws InterruptedException {
        // 判断队列是否为空
        if (size == 0) {
            // wait();
            this.wait(); // 消费者阻塞，等待生产者唤醒
            //throw new RuntimeException("队列为空");
        }

        // 队列不为空
        int element = queue[frontIndex];
        frontIndex += 1;
        if (frontIndex == queue.length) {
            frontIndex = 0;
        }

        size--;
        // 消费者消费掉一个元素，队列一定不满了
        // 尝试唤醒一个生产者了
        this.notify();   // 试图唤醒等待的生产者

        return element;
    }

}
