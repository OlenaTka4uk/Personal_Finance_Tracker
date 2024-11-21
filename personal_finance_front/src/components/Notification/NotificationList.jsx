const NotificationList = ({ notifications }) => (
    <ul>
        {notifications.map(notification => (
            <li key={notification.id}>{notification.message}</li>
        ))}
    </ul>
);
export default NotificationList;
