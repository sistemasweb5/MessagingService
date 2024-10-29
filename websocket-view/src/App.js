import './App.css';
import { useState, useEffect } from 'react';

// Componentes para el chat
function ChatHeader({ channelName }) {
  return <div className="Chat-header">{channelName}</div>;
}

function ChatMessages({ messages }) {
  return (
    <div className="Chat-messages">
      {messages.map((message, index) => (
        <div
          key={index}
          className={`Chat-message ${message.isUser ? 'user' : 'other'}`}
        >
          {message.content}
        </div>
      ))}
    </div>
  );
}

function ChatInput({ onSendMessage }) {
  const [message, setMessage] = useState('');

  const handleSend = () => {
    if (message.trim()) {
      onSendMessage(message);
      setMessage('');
    }
  };

  return (
    <div className="Chat-input">
      <textarea
        value={message}
        onChange={(e) => setMessage(e.target.value)}
        placeholder="Escribe un mensaje..."
      />
      <button onClick={handleSend}>Enviar</button>
    </div>
  );
}

function App() {
  const [messages, setMessages] = useState([]);

  useEffect(() => {
    // Aquí iría el código para conectar con el servicio de mensajería (MessageRepository) y obtener los mensajes
  }, []);

  const handleSendMessage = (content) => {
    const newMessage = { content, isUser: true };
    setMessages([...messages, newMessage]);
    // Aquí iría el código para enviar el mensaje al servicio de mensajería
  };

  return (
    <div className="App">
      <ChatHeader channelName="Canal General" />
      <ChatMessages messages={messages} />
      <ChatInput onSendMessage={handleSendMessage} />
    </div>
  );
}

export default App;
