import React, { useState } from 'react';
import axios from 'axios';

const MessageInput = ({ onNewMessage }) => {
    const [message, setMessage] = useState('');

    const handleSend = async () => {
        await axios.post('/messages', { Content: message });
        setMessage('');
        onNewMessage();
    };

    return (
        <div className="message-input">
            <input 
                type="text" 
                value={message} 
                onChange={(e) => setMessage(e.target.value)} 
                placeholder="Escribe un mensaje..." 
            />
            <button onClick={handleSend}>Enviar</button>
        </div>
    );
};

export default MessageInput;
