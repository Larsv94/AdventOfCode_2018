import GetInput from './input';

GetInput('input.csv')
    .then((data)=>handleData(data))
    .catch((err)=>console.log(err))

const handleData = (data)=>{
    let min = {x:999,y:999}
    let max = {x:0,y:0}
    data.forEach(obj => {
        min = {
            x:Math.min(obj.x,min.x),
            y:Math.min(obj.y,min.y)
        }
        max = {
            x:Math.max(obj.x,max.x),
            y:Math.max(obj.y,max.y)
        }
    });

    let area = new Array(data.length);
    let distanceArea = 0
    
    for(let x = min.y;x<max.x+1;x++){
        for(let y = min.y;y<max.y+1;y++){

            const getDistance = ManhattanDistance({x:x,y:y})

            let totalDistance = 0;
            let smallestDistance=99999999999;
            let closestCoordinate = -1;
            for (let z = 0; z < data.length; z++) {
                const element = data[z];
                const distance = getDistance(element);

                totalDistance+=distance;

                if ( distance < smallestDistance) {
                    smallestDistance = distance;
                    closestCoordinate = z;
                }else if(distance === smallestDistance){
                    smallestDistance=distance;
                    closestCoordinate =-1;
                }
              
            }
            if(closestCoordinate!==-1){
                area[closestCoordinate]=(area[closestCoordinate]||0)+1
            }

            if(totalDistance<10000){
                distanceArea++;
            }
            
        }
    
    }

    area = area.filter((_,i)=>{
        let item = data[i]
        if(item.x==max.x||item.x==min.x){
            return false
        }
        if(item.y==max.y||item.y==min.y){
            return false
        }
        return true
    })

    console.log("Part 1")
    console.log(Math.max(...area))

    console.log("Part 2")
    console.log(distanceArea)
    
}

const ManhattanDistance = point1=>point2=>{
    return Math.abs(point1.x-point2.x)+Math.abs(point1.y-point2.y)
}