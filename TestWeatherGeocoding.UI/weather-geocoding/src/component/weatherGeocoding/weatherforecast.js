import TemperatureInfo from './temperatureInfo';
import { useSelector } from 'react-redux';
import { Row, Col } from 'react-bootstrap';

const WeatherForecast = () => {
 
    const selector = useSelector((state) => state.weatherGeocoding);

    if (!selector.data || !selector.data.properties) {
        return <p className='p-2'>{selector.error}</p>;
      }
      
  const { temperature, maxTemperature, minTemperature } = selector.data.properties;
  return (
    <div className='pt-4'>
        <Row>
            <Col><TemperatureInfo temperatureData={temperature.values} title={"Temperature Info"}/></Col>
            <Col><TemperatureInfo temperatureData={maxTemperature.values} title={"Max Temperature"}/></Col>
            <Col><TemperatureInfo temperatureData={minTemperature.values} title={"Min Temperature"}/></Col>
        </Row>
    </div>
  );
};

export default WeatherForecast;
