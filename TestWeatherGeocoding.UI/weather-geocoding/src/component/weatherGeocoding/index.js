import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getData } from "../../redux/weatherGeocoding/actions";
import WeatherForecast from "./weatherforecast";
import { Container, Row, Col, InputGroup, FormControl, Button } from 'react-bootstrap';

function WeatherGeocoding() {
  const dispatch = useDispatch();
  const selector = useSelector((state) => state.weatherGeocoding);
  const [address, setAddress] = useState("");
  const [data] = useState(selector.data);
  
  const getWeatherForecast = async () => {
    await dispatch(getData(address));
  };

  return (
    <Container className="mt-5 text-center">
      <Row className="justify-content-center">
        <Col md={6} pt={2}>
          <InputGroup>
            <FormControl
              type="text"
              value={address}
              placeholder="Ex: 4600 Silver Hill Rd, Washington, DC 20233"
              onChange={(e) => setAddress(e.target.value)}
            />
            <Button variant="success" className="ml-2" onClick={getWeatherForecast}>
              Get Forecast
            </Button>
          </InputGroup>
        </Col>
        <Col md={8} pt={2}>
        <div>
            {data ? (
              <WeatherForecast weatherData={data} />
            ) : (
              <p>Loading...</p>
            )}
          </div>
        </Col>
      </Row>
    </Container>
  );
}

export default WeatherGeocoding;
