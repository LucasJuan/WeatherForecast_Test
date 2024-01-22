import React, { useState } from 'react';
import moment from 'moment';
import { Accordion, Card } from 'react-bootstrap';

const TemperatureInfo = ({ temperatureData, title }) => {
  const [activeIndex, setActiveIndex] = useState(null);

  const handleAccordionToggle = (index) => {
    setActiveIndex((prevIndex) => (prevIndex === index ? null : index));
  };

  const groupedData = temperatureData.reduce((result, item) => {
    const startDate = moment(item.validTime.split('/')[0]);
    const date = startDate.format('YYYY-MM-DD');
    if (!result[date]) {
      result[date] = [];
    }
    result[date].push({ ...item, startDate });
    return result;
  }, {});

  return (
    <>
    <h5>{title}</h5>
    <Accordion activeKey={activeIndex} onSelect={handleAccordionToggle}>
      {Object.entries(groupedData).map(([date, temperatures], index) => (
        <Card key={index}>
          <Accordion.Item eventKey={index.toString()}>
            <Accordion.Header>
              {moment(date).format('MM/DD/YYYY')}
            </Accordion.Header>
            <Accordion.Body>
              {temperatures.map((temp, innerIndex) => (
                <div key={`${date}_${innerIndex}`}>
                  <p>
                    Valid Time: {temp.startDate.format('MM/DD/YYYY HH:mm:ss')}
                  </p>
                  <p>
                    Temperature: {temp.value.toFixed(2)} °F
                  </p>
                </div>
              ))}
            </Accordion.Body>
          </Accordion.Item>
        </Card>
      ))}
    </Accordion>
    </>
    
  );
};

export default TemperatureInfo;