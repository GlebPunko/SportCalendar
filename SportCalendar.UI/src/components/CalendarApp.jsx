import { useState } from "react";

const CalendarApp = () => {
	const dayOfWeek = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
	const monthsOfYear = [
		"January",
		"Febreary",
		"March",
		"April",
		"May",
		"June",
		"Jule", 
		"August", 
		"September", 
		"October", 
		"November", 
		"December"
	];

	const currentDate = new Date();

	const [currentMonth, setCurrentMonth] = useState(currentDate.getMonth());
	const [currentYear, setCurrentYear] = useState(currentDate.getFullYear());
	const [selectedDate, setSelectedDate] = useState(currentDate);
	const [showPopup, setShowPopup] = useState(false);

	const daysInMonth = new Date(currentYear, currentMonth + 1, 0).getDate();
	const firstDayOfMonth = new Date(currentYear, currentMonth, 1).getDay();

	const prevMonth = () => {
		setCurrentMonth((prevMonth) => (prevMonth === 0 ? 11 : prevMonth - 1));
		setCurrentYear(prevYear => (currentMonth === 0 ? prevYear - 1 : prevYear));
	}

	const nextMonth = () => {
		setCurrentMonth((nextMonth) => (nextMonth === 11 ? 0 : nextMonth + 1));
		setCurrentYear(nextYear => (currentMonth === 11 ? nextYear + 1 : nextYear));
	}

	const handleDayClick = (day) => {
		const clickedDate = new Date(currentYear, currentMonth, day);
		const today = new Date();

		if(clickedDate >= today) {
			setSelectedDate(clickedDate);
			setShowPopup(!showPopup);
		}
	}

  return (
    <div className='calendar-app'>
        <div className='calendar'>
            <h1 className='heading'>Sport calendar</h1>
            <div className='navigate-date'>
                <h2 className='month'>{monthsOfYear[currentMonth]},</h2>
                <h2 className='year'>{currentYear}</h2>
                <div className="buttons">
                    <i className="bx bx-chevron-left" onClick={prevMonth}></i>      
                    <i className="bx bx-chevron-right" onClick={nextMonth}></i>    
                </div>
            </div>
            <div className="weekdays">
                {dayOfWeek.map((day) => <span key={day}>{day}</span>)}
            </div>
            <div className="days">
                {[...Array(firstDayOfMonth).keys()].map((_, index) => (
									<span key={`empty-${index}`}/>
								))}
								{[...Array(daysInMonth).keys()].map((day) => (
									<span 
										key={day + 1} 
										className={
											day + 1 === currentDate.getDate() &&
									 		currentMonth === currentDate.getMonth() &&
											currentYear === currentDate.getFullYear() 
											? 'current-day' 
											: '' 
										}
										onClick={handleDayClick}
									>
										{day + 1}
									</span>
								))}
            </div>
        </div>
        <div className="events">
            <div className="event-popup">
                <div className="time-input">
                    <div className="event-popup-time">
                        <input type="number" name = "hours" min={0} max={24} className="hours"/>
                        <input type="number" name = "minutes" min={0} max={24} className="minutes"/>
                        <textarea placeholder="Enter sport activity (Maximum 10 characters)"></textarea>
                        <button className="event-popup-btn">Add sport activity</button>
                        <button className="close-event-popup">
                            <i className="bx bx-x"></i>
                        </button>
                    </div>
                </div>
            </div>
            <div className="event">
                <div className="event-date-wrapper">
                    <div className="event-date">May, 15, 2024</div>
                    <div className="event-time">May, 15, 2024</div>
                </div>
                <div className="event-text">Running</div>
                <div className="event-buttons">
                    <i className="bx bxs-edit-alt"></i>
                    <i className="bx bxs-message-alt-x"></i>
                </div>
            </div>
        </div>
    </div>
  )
}

export default CalendarApp