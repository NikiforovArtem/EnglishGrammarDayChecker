import React, { useState } from 'react';
import axios from 'axios';

const axiosRequestConfig1 = {
    headers: {
      'cache-control': 'no-cache',
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
  };

function NewTaskModal({ onClose, onCreateTask }) {
  const [newTask, setNewTask] = useState('');
  const [newTaskURL, setNewTaskURL] = useState('');

  const createTask = async () => {
    try {
      await axios.post(process.env.REACT_APP_API_URL + '/grammar/save', {
        name: newTask,
        url: newTaskURL,
      }, axiosRequestConfig1);
      // After creating a new task, call the callback function to update the task list
      onCreateTask();
      onClose(); // Close the modal
      setNewTask('');
      setNewTaskURL('');
    } catch (error) {
      console.error('Error creating task:', error);
    }
  };

  return (
    <div className="modal">
      <div className="modal-content">
      
      <div className='modal-header'>
      Create New Task
      <button className="close-button" onClick={onClose}>
          &times;
        </button>
        
        </div>
      <div className="input-container">
          <input
            type="text"
            id="taskName"
            placeholder="Name"
            value={newTask}
            onChange={(e) => setNewTask(e.target.value)}
          />
        </div>
        <div className="input-container">
          <input
          type="text"
          placeholder="URL"
          value={newTaskURL}
          onChange={(e) => setNewTaskURL(e.target.value)}
        />
        </div>
        <div className="input-container-button" style={{ textAlign: 'right' }}>
        <button className='create-button-modal' onClick={createTask}>Create Task</button>
        </div>
      </div>
    </div>
  );
}

export default NewTaskModal;
