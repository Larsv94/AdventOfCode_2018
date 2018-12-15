import fs from 'fs';
import parse from 'csv-parser';

export default (path) => {
    return new Promise((resolve, reject)=>{

        let output =[]
        
        const parseStream = parse({
            trim: true,
            skip_empty_lines: true
          });

        fs.createReadStream(path)
        .pipe(parseStream)
        .on('data', function(data){
            try {
                output = output.concat(data);
            }
            catch(err) {
                reject(err);
            }
        })
        .on('end',function(){
            resolve(output);
        });  
    })
}