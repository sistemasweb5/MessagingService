import React from 'react';

const MessageList = ({ messages }) => {
    return (
        <div className="message-list">
            {messages.map((msg) => (
                <div key={msg.MessageId}>
                    <strong>{msg.UserId}: </strong>
                    <span>{msg.Content}</span>
                </div>
            ))}
        </div>
    );
};

export default MessageList;
