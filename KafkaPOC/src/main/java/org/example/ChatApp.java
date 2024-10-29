package org.example;

import java.util.Scanner;

public class ChatApp {
    public static void main(String[] args) {
        String bootstrapServers = "localhost:9092";
        String topic = "chat-messages";
        String userId = args[0];

        Producer producer = new Producer(bootstrapServers);
        Consumer consumer = new Consumer(bootstrapServers, "chat-group-" + userId);

        producer.sendMessage(topic, userId + " has connected");

        new Thread(() -> {
            consumer.subscribe(topic);
            consumer.pollMessages(userId);
        }).start();

        Scanner scanner = new Scanner(System.in);
        System.out.println("Chat started. Type your messages below:");

        while (true) {
            String message = scanner.nextLine();
            if (message.equalsIgnoreCase("exit")) {
                break;
            }
            producer.sendMessage(topic, userId + ": " + message);
        }

        producer.close();
        consumer.close();
        scanner.close();
    }
}
