package org.example;

import org.apache.kafka.clients.consumer.ConsumerRecord;
import org.apache.kafka.clients.consumer.KafkaConsumer;
import org.apache.kafka.clients.consumer.ConsumerRecords;
import java.time.Duration;
import java.util.Collections;
import java.util.Properties;

public class ChatConsumer {
    private KafkaConsumer<String, String> consumer;
    private String topic = "chat-messages";

    public ChatConsumer(String groupId) {
        Properties props = new Properties();
        props.put("bootstrap.servers", "localhost:9092");
        props.put("group.id", groupId);
        props.put("key.deserializer", "org.apache.kafka.common.serialization.StringDeserializer");
        props.put("value.deserializer", "org.apache.kafka.common.serialization.StringDeserializer");

        consumer = new KafkaConsumer<>(props);
        consumer.subscribe(Collections.singletonList(topic));
    }

    public void listen() {
        while (true) {
            ConsumerRecords<String, String> records = consumer.poll(Duration.ofMillis(100));
            for (ConsumerRecord<String, String> record : records) {
                System.out.printf("Received message: [%s] from user: [%s]%n", record.value(), record.key());
            }
        }
    }

    public static void main(String[] args) {
        ChatConsumer chatConsumer = new ChatConsumer("group1");
        chatConsumer.listen();
    }
}
