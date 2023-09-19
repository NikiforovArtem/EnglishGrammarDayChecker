import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './style.css';
import NewTaskModal from './NewTaskModal'; // Import the new component

function App() {
  const [tasks, setTasks] = useState([]);
  const [updatedTask, setUpdatedTask] = useState('');
  const [showModal, setShowModal] = useState(false); // State to control modal visibility

  const axiosRequestConfig = {
    headers: {
      'cache-control': 'no-cache',
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    },
  };
  
  

  useEffect(() => {
    // Fetch actual grammar tasks when the component mounts
    fetchTasks();
  }, []);

  const fetchTasks = async () => {
    try {
      const response = await axios.get(process.env.REACT_APP_API_URL + '/grammar/actual', axiosRequestConfig);
      setTasks(response.data);
    } catch (error) {
      console.error('Error fetching tasks:', error);
    }
  };

  const toggleModal = () => {
    setShowModal(!showModal); // Toggle modal visibility
  };

  const updateTask = async (taskId) => {
    // Find the task index in the array
    const taskIndex = tasks.findIndex((task) => task.id === taskId);
  
    if (taskIndex !== -1) {
      // Create a copy of the tasks array
      const updatedTasks = [...tasks];
      updatedTasks[taskIndex].isDoneToday = true;
  
      try {
        // Send the request to update the task on the server
        await axios.post(process.env.REACT_APP_API_URL + '/grammar/done', {
          taskId: taskId,
        }, axiosRequestConfig);
  
        // Update the local state
        setTasks(updatedTasks);
        fetchTasks();
      } catch (error) {
        // If the server request fails, revert the local state
        updatedTasks[taskIndex].isDoneToday = false;
        setTasks(updatedTasks);
        console.error('Error marking task as done:', error);
      }
    }
  };

  return (
    <div className="app-container">
      <header className="header">
        <h1 className="title">English Grammar Tasks</h1>
        <nav className="nav">
          <a href="#">Home</a>
          <a href="#">About</a>
          <a href="#">Contact</a>
        </nav>
      </header>

      <main className="main-content">
      <div className="create-button-container">
          <button className="create-button" onClick={toggleModal}>
            +
          </button>
        </div>
        <table className="task-table">
  <thead>
    <tr>
      <th>Task Name</th>
      <th>URL</th>
      <th>Total completions count</th>
      <th>Is Done Today</th>
      <th>Action</th>
    </tr>
  </thead>
  <tbody>
    {tasks.map((task) => (
      <tr key={task.id}>
        <td>{task.name}</td>
        <td><href>{task.url}</href></td>
        <td>{task.totalCompletionsCount}</td>
        <td>{task.isDoneToday ? 'Yes' : 'No'}</td>
        <td>
        {task.isDoneToday ? '' : <button className="create-button" onClick={() => updateTask(task.id)}>Done</button>}
        </td>
      </tr>
    ))}
  </tbody>
</table>
      </main>

      {showModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <NewTaskModal onClose={toggleModal} onCreateTask={fetchTasks} />
          </div>
        </div>
      )}
    </div>
  );
    }

    
export default App;