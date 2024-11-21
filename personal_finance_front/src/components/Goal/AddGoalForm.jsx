import React, { useState } from 'react';
const AddGoalForm = ({ onAddGoal }) => {
    const [goalName, setGoalName] = useState('');
    const [targetAmount, setTargetAmount] = useState('');
    const handleSubmit = (e) => {
        e.preventDefault();
        onAddGoal({ goalName, targetAmount });
    };
    return (
        <form onSubmit={handleSubmit}>
            <input type="text" placeholder="Goal Name" onChange={(e) => setGoalName(e.target.value)} />
            <input type="number" placeholder="Target Amount" onChange={(e) => setTargetAmount(e.target.value)} />
            <button type="submit">Add Goal</button>
        </form>
    );
};
export default AddGoalForm;
