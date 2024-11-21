import React from 'react';
const GoalList = ({ goals }) => (
    <ul>
        {goals.map(goal => (
            <li key={goal.id}>
                {goal.name} - {goal.progress}%
            </li>
        ))}
    </ul>
);
export default GoalList;
