import {
    useEffect,
    useState
} from 'react';
import WatchApiService from '../../services/watchapi.js';
import {red} from '@mui/material/colors';

const CandidateDashboard = () =>{
    const [document, setDocument] = useState([]);

    useEffect(() =>
              {
                  WatchApiService.getDocument().then( response =>
                                                      {
                                                          setDocument(
                                                              response.data);
                                                          console.log(response.data);
                                                      }
                  ).catch(error =>{
                      console.log(error);
                                                                         }
                  )
              }, []);


    return (
        <div>
            <h1>Documents</h1>
            <ul>
                {document.map(doc => {
                    return(
                        <li key={doc.id}><a href={doc.path}>{doc.label}</a></li>
                    );
                })}
            </ul>
        </div>
    );
}

export default CandidateDashboard;