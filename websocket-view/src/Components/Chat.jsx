import React, { useEffect, useState } from 'react';
import axios from 'axios';
import MessageList from './MessageList';
import MessageInput from './MessageInput';
import '../Style/chat.css';

const Chat = () => {
    const [messages, setMessages] = useState([]);

    const fetchMessages = async () => {
        const response = await axios.get('/messages'); // Asume que tienes configurado un proxy
        setMessages(response.data);
    };

    useEffect(() => {
        fetchMessages();
    }, []);

    return (
        <div className="chat-container">
            <MessageList messages={messages} />
            <MessageInput onNewMessage={fetchMessages} />
        </div>
    );
};

export default Chat;
