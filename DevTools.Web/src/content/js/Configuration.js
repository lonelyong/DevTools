class ProductionConfiguration{
    apiHost='https://api.link.hicode.net';
    host='https://link.hicode.net'
}
class DevelopmentConfiguration{
    apiHost='http://localhost:51744';
    host='http://localhost:3000'
}
const isDevelopment = false;
const Configs = isDevelopment ? new DevelopmentConfiguration() : new ProductionConfiguration();

export default Configs;