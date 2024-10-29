package org.example;

import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerRecord;
import java.util.Properties;

public class ChatProducer {
    private KafkaProducer<String, String> producer;
    private String topic = "chat-messages";

    public ChatProducer() {
        Properties props = new Properties();
        props.put("bootstrap.servers", "localhost:9092");
        props.put("key.serializer", "org.apache.kafka.common.serialization.StringSerializer");
        props.put("value.serializer", "org.apache.kafka.common.serialization.StringSerializer");

        producer = new KafkaProducer<>(props);
    }

    public void sendMessage(String user, String message) {
        producer.send(new ProducerRecord<>(topic, user, message));
    }

    public void close() {
        producer.close();
    }

    public static void main(String[] args) {
        ChatProducer chatProducer = new ChatProducer();
        chatProducer.sendMessage("User1", "Hello User2!");
        chatProducer.close();
    }
}

