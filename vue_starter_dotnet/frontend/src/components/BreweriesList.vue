<template>
    <table>
        <thead>
            <tr>
                <td>Id</td>
                <td>Name</td>
                <td>Brewer</td>
            </tr>
        </thead>
        <tbody>
            <tr v-for="brewery in breweries" :key="brewery.Id">
                <td>{{brewery.Id}}</td>
                <td>{{brewery.Name}}</td>
                <td>{{brewery.Brewer}}</td>
            </tr>
        </tbody>
    </table>
</template>