const NotificationBadge = ({ count }) => (
    <div className="notification-badge">
        {count > 0 && <span>{count}</span>}
    </div>
);
export default NotificationBadge;
